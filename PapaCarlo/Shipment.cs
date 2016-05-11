using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities.Hosting;
using System.Activities;
using System.Activities.Statements;
using PapaCarloDBApp;


namespace PapaCarlo
{
    public sealed class Shipment : CodeActivity
    {
        [RequiredArgument]
        public InArgument<ContractShipment> contr { get; set; }

        [RequiredArgument]
        public InArgument<QueryContractShipment> query { get; set; }

        [RequiredArgument]
        public InArgument<int> Id { get; set; }

        [RequiredArgument]
        public InArgument<int> oldAmount { get; set; }

        [RequiredArgument]
        public InArgument<int> storeId { get; set; }

        public InArgument<int> mov { get; set; }

        public OutArgument<bool> Result { get; set; }

        public static List<ReportBalanceTable> querySelectReportBalanceByShip(ContractShipment co, int storeId)
        {
            
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from c in db.ReportBalances
                                join sc in db.StoreCells on c.StoreCellId equals sc.Id
                                join sh in db.Storehouses on sc.StorehouseId equals sh.Id
                                join p in db.Products on c.ProductId equals p.Id
                                select new { c, p, sc, sh };

                    List<ReportBalanceTable> table = new List<ReportBalanceTable>();

                    foreach (var item in query)
                    {
                        if (co.ProductId == item.p.Id && co.StoreCellFromId == item.sc.Id
                            && item.sh.Id == storeId)
                        table.Add(new ReportBalanceTable(item.c, item.p, item.sc, item.sh));
                    }
                    return table;
                }
        }

        public static bool queryUpdateReportBalance(ReportBalance c)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    ReportBalance p = db.ReportBalances.Find(c.Id);

                    p.Amount = c.Amount;
                    p.ProductId = c.ProductId;
                    p.Date = c.Date;
                    p.StoreCellId = c.StoreCellId;

                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }

        public static void restore(ContractShipment co, int oldAmount)
        {
            ReportBalance rb = new ReportBalance();
            rb.Amount = oldAmount - co.Amount;
            rb.Date = co.Date;
            rb.Id = new Random().Next();
            rb.ProductId = co.ProductId;
            rb.StoreCellId = co.StoreCellFromId;
            new QueryReports().queryAddReportBalance(rb);
        }

        protected override void Execute(CodeActivityContext context)
        {
            ContractShipment co = contr.Get(context);
            QueryContractShipment q = query.Get(context);
            int id = Id.Get(context);

            /*if (co.Amount < 0)
            {
                Result.Set(context, false);
                return;
            }*/
            
            List<ReportBalanceTable> res = querySelectReportBalanceByShip(co, storeId.Get(context));
            if (res == null || res.Count == 0)
            {
                if (oldAmount.Get(context) == 0 && mov.Get(context) != 1)
                {
                    Result.Set(context, false);
                    return;
                }
                else
                {
                    Shipment.restore(co, oldAmount.Get(context));


                    if (mov.Get(context) != 1)
                    {
                        if (id == -1)
                        {
                            q.queryAddContractShipment(co);
                        }
                        else
                        {
                            co.Id = id;
                            q.queryUpdateContractShipment(co);
                        }
                    }
                    Result.Set(context, true);
                    return;
                }
                
            }


            res[0].reportBalance.Amount -= (co.Amount - oldAmount.Get(context));

            if (res[0].reportBalance.Amount < 0)
            {
                Result.Set(context, false);
                return;
            }

            if (mov.Get(context) != 1)
            {
                if (id == -1)
                {
                    q.queryAddContractShipment(co);
                }
                else
                {
                    co.Id = id;
                    q.queryUpdateContractShipment(co);
                }
            }
            
            if (res[0].reportBalance.Amount > 0)
            {
                queryUpdateReportBalance(res[0].reportBalance);
            } 
            else
            {
                new QueryReports().queryDeleteReportBalance(res[0].reportBalance.Id);
            }
 

            Result.Set(context, true);
        }
    }
}
