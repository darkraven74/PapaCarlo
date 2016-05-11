using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaCarloDBApp;

namespace WorkflowConsoleApplication1
{
    class MyUtils
    {
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

        public static int restore(ContractShipment co, int oldAmount)
        {
            ReportBalance rb = new ReportBalance();
            rb.Amount = oldAmount - co.Amount;
            rb.Date = co.Date;
            rb.Id = new Random().Next();
            rb.ProductId = co.ProductId;
            rb.StoreCellId = co.StoreCellFromId;
            new QueryReports().queryAddReportBalance(rb);
            return 1;
        }
    }
}
