using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class QueryReports
    {
        public List<ReportBalanceTable> querySelectReportBalance(DateTime date)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from c in db.ReportBalances
                                join sc in db.StoreCells on c.StoreCellId equals sc.Id
                                join sh in db.Storehouses on sc.StorehouseId equals sh.Id
                                join p in db.Products on c.ProductId equals p.Id
                                where c.Date == date
                                select new { c, p, sc, sh };

                    List<ReportBalanceTable> table = new List<ReportBalanceTable>();

                    foreach (var item in query)
                    {
                        table.Add(new ReportBalanceTable(item.c, item.p, item.sc, item.sh));
                    }
                    return table;
                }
            }
            return null;
        }

        public List<ReportBalanceTable> querySelectReportBalance()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
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
                        table.Add(new ReportBalanceTable(item.c, item.p, item.sc, item.sh));
                    }
                    return table;
                }
            }
            return null;
        }

        public List<ReportPredictTable> querySelectReportPredict(DateTime date)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from c in db.ReportPredicts
                                join sh in db.Storehouses on c.StorehouseId equals sh.Id
                                join p in db.Products on c.ProductId equals p.Id
                                //join cs in db.ContractSupplys on c.ContractSupplyId equals cs.Id
                                where c.Date == date
                                select new { c, p, sh };

                    List<ReportPredictTable> table = new List<ReportPredictTable>();

                    foreach (var item in query)
                    {
                        table.Add(new ReportPredictTable(item.c, item.p, item.sh));
                    }
                    return table;
                }
            }
            return null;
        }

        public List<ReportPredictTable> querySelectReportPredict()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from c in db.ReportPredicts
                                join sh in db.Storehouses on c.StorehouseId equals sh.Id
                                join p in db.Products on c.ProductId equals p.Id
                                select new { c, p, sh };

                    List<ReportPredictTable> table = new List<ReportPredictTable>();

                    foreach (var item in query)
                    {
                        table.Add(new ReportPredictTable(item.c, item.p, item.sh));
                    }
                    return table;
                }
            }
            return null;
        }

        public bool queryAddReportBalance(ReportBalance c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.ReportBalances.Add(c);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        /*public bool queryUpdateReportBalance(ReportBalance c)
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
        }*/

        public bool queryDeleteReportBalance(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ReportBalance p = db.ReportBalances.Find(Id);
                        db.ReportBalances.Remove(p);

                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public ReportBalance queryFindReportBalanceById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.ReportBalances.Find(Id);
                }
            }
            return null;
        }

        public bool queryAddReportPredict(ReportPredict c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.ReportPredicts.Add(c);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

       /* public bool queryUpdateReportPredict(ReportPredict c)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    ReportPredict p = db.ReportPredicts.Find(c.Id);

                    p.Amount = c.Amount;
                    p.ProductId = c.ProductId;
                    p.Date = c.Date;
                    p.Predict = c.Predict;
                    p.StorehouseId = c.StorehouseId;
                    p.ContractSupplyId = c.ContractSupplyId;

                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
        }*/

        public bool queryDeleteReportPredict(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ReportPredict p = db.ReportPredicts.Find(Id);
                        db.ReportPredicts.Remove(p);

                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public ReportPredict queryFindReportPredictById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.ReportPredicts.Find(Id);
                }
            }
            return null;
        }
    }
}
