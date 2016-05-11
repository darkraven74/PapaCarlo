using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class QueryContractMove
    {
        public List<ContractMoveTable> querySelectContractsMove(DateTime date)
        {
           if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {

                    var query = from c in db.ContractMoves
                                join scFrom in db.StoreCells on c.StoreCellFromId equals scFrom.Id
                                join scTo in db.StoreCells on c.StoreCellToId equals scTo.Id
                                join shFrom in db.Storehouses on scFrom.StorehouseId equals shFrom.Id
                                join shTo in db.Storehouses on scTo.StorehouseId equals shTo.Id
                                join pr in db.Products on c.ProductId equals pr.Id
                                where c.Date == date
                                select new { c, scFrom, scTo, shFrom, shTo, pr };

                    List<ContractMoveTable> table = new List<ContractMoveTable>();

                    foreach (var item in query)
                    {
                        item.c.ProductObj = item.pr;
                        table.Add(new ContractMoveTable(item.c, item.scFrom, item.scTo, item.shFrom, item.shTo));
                    }
                    return table;
                }
            }
            return null;
        }

        public List<ContractMoveTable> querySelectContractsMove()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {

                    var query = from c in db.ContractMoves
                                join scFrom in db.StoreCells on c.StoreCellFromId equals scFrom.Id
                                join scTo in db.StoreCells on c.StoreCellToId equals scTo.Id
                                join shFrom in db.Storehouses on scFrom.StorehouseId equals shFrom.Id
                                join shTo in db.Storehouses on scTo.StorehouseId equals shTo.Id
                                join pr in db.Products on c.ProductId equals pr.Id
                                select new { c, scFrom, scTo, shFrom, shTo, pr };

                    List<ContractMoveTable> table = new List<ContractMoveTable>();

                    foreach (var item in query)
                    {
                        item.c.ProductObj = item.pr;
                        table.Add(new ContractMoveTable(item.c, item.scFrom, item.scTo, item.shFrom, item.shTo));
                    }
                    return table;
                }
            }
            return null;
        }

        public bool queryAddContractMove(ContractMove c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.ContractMoves.Add(c);
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

        public bool queryUpdateContractMove(ContractMove c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ContractMove contract = db.ContractMoves.Find(c.Id);

                        contract.StoreCellToId = c.StoreCellToId;
                        contract.StoreCellFromId = c.StoreCellFromId;
                        contract.ProductId = c.ProductId;
                        contract.Amount = c.Amount;
                        contract.Date = c.Date;

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

        public bool queryDeleteContractMove(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ContractMove contract = db.ContractMoves.Find(Id);
                        db.ContractMoves.Remove(contract);

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

        public ContractMove queryFindContractMoveById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    ContractMove c = db.ContractMoves.Find(Id);
                    c.StoreCellFromObj = c.StoreCellFromObj;
                    c.StoreCellToObj = c.StoreCellToObj;
                    //StoreCellTable sct = new StoreCellTable(c.StoreCellFromObj,
                    return c;
                }
            }
            return null;
        }


    }

    public class QueryContractSupply
    {
        public List<ContractSupplyTable> querySelectContractsSupply(DateTime date)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query2 = from c in db.ContractSupplys
                                 join sh in db.Contractors on c.ContractorId equals sh.Id
                                 where c.Date == date
                                 select new { c, sh };

                    List<ContractSupplyTable> table = new List<ContractSupplyTable>();
                    foreach (var item1 in query2)
                    {
                        table.Add(new ContractSupplyTable(item1.c, item1.sh));
                    }

                    return table;
                }
            }
            return null;
        }


        public List<ContractSupplyTable> querySelectContractsSupply()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query2 = from c in db.ContractSupplys
                                 join sh in db.Contractors on c.ContractorId equals sh.Id
                                 select new { c, sh };

                    List<ContractSupplyTable> table = new List<ContractSupplyTable>();
                    foreach (var item1 in query2)
                    {
                        table.Add(new ContractSupplyTable(item1.c, item1.sh));
                    }

                    return table;
                }
            }
            return null;
        }


        public List<ProductAmountTable> querySelectContractsSupplyProducts(int contractSupplyId)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {

                    /* var query1 = from c in db.ContractSupplys
                                  where c.Date == date
                                  select c.Id;


                     var query3 = from s in db.SupplyProducts
                                  join p in db.Products on s.ProductId equals p.Id
                                  where query1.Contains(s.ContractSupplyId)
                                  select new { s, p };*/

                    var query3 = from s in db.SupplyProducts
                                 join p in db.Products on s.ProductId equals p.Id
                                 where s.ContractSupplyId == contractSupplyId
                                 select new { s, p };

                    List<ProductAmountTable> prodAmount = new List<ProductAmountTable>();


                    foreach (var item2 in query3)
                    {
                        prodAmount.Add(new ProductAmountTable(item2.s.ContractSupplyId, item2.p, item2.s.Amount));
                    }
                    return prodAmount;
                }
            }
            return null;
        }

        public bool queryAddContractSupply(ContractSupply c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.ContractSupplys.Add(c);
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

        public bool queryUpdateContractSupply(ContractSupply c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ContractSupply contract = db.ContractSupplys.Find(c.Id);

                        contract.ContractorId = c.ContractorId;
                        contract.numberOfSupply = c.numberOfSupply;
                        contract.wasReceived = c.wasReceived;
                        contract.Date = c.Date;
                        db.SupplyProducts.RemoveRange(contract.SupplyProducts);
                        contract.SupplyProducts = c.SupplyProducts;
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

        public bool queryDeleteContractSupply(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ContractSupply contract = db.ContractSupplys.Find(Id);
                        List<SupplyProduct> sp = contract.SupplyProducts;
                        db.SupplyProducts.RemoveRange(sp);
                        db.ContractSupplys.Remove(contract);

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

        public ContractSupply queryFindContractSupplyById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    ContractSupply s = db.ContractSupplys.Find(Id);
                    //List<SupplyProduct> lsp = db.SupplyProducts.Select(it => new SupplyProduct() { Id = it.Id, ProductId = it.ProductId, Amount = it.Amount, ContractSupplyId = it.ContractSupplyId }).Where(r => r.ContractSupplyId == Id).ToList();
                    s.SupplyProducts = s.SupplyProducts;

                    return s;
                }
            }

            return null;
        }
    }

    public class QueryContractShipment
    {
        public List<ContractShipmentTable> querySelectContractsShipment(DateTime date)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {

                    var query = from c in db.ContractShipments
                                join scFrom in db.StoreCells on c.StoreCellFromId equals scFrom.Id
                                join shFrom in db.Storehouses on scFrom.StorehouseId equals shFrom.Id
                                join pr in db.Products on c.ProductId equals pr.Id
                                where c.Date == date
                                select new { c, scFrom, shFrom, pr };

                    List<ContractShipmentTable> table = new List<ContractShipmentTable>();

                    foreach (var item in query)
                    {
                        item.c.ProductObj = item.pr;
                        table.Add(new ContractShipmentTable(item.c, item.scFrom, item.shFrom));
                    }
                    return table;
                }
            }
            return null;
        }

        public List<ContractShipmentTable> querySelectContractsShipment()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {

                    var query = from c in db.ContractShipments
                                join scFrom in db.StoreCells on c.StoreCellFromId equals scFrom.Id
                                join shFrom in db.Storehouses on scFrom.StorehouseId equals shFrom.Id
                                join pr in db.Products on c.ProductId equals pr.Id
                                select new { c, scFrom, shFrom, pr };

                    List<ContractShipmentTable> table = new List<ContractShipmentTable>();

                    foreach (var item in query)
                    {
                        item.c.ProductObj = item.pr;
                        table.Add(new ContractShipmentTable(item.c, item.scFrom, item.shFrom));
                    }
                    return table;
                }
            }
            return null;
        }

        public bool queryAddContractShipment(ContractShipment c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.ContractShipments.Add(c);
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

        public bool queryUpdateContractShipment(ContractShipment c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ContractShipment contract = db.ContractShipments.Find(c.Id);

                        contract.ProductId = c.ProductId;
                        contract.Amount = c.Amount;
                        contract.StoreCellFromId = c.StoreCellFromId;
                        contract.Date = c.Date;

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

        public bool queryDeleteContractShipment(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ContractShipment contract = db.ContractShipments.Find(Id);
                        db.ContractShipments.Remove(contract);

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

        public ContractShipment queryFindContractShipmentById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    ContractShipment c = db.ContractShipments.Find(Id);
                    c.StoreCellFromObj = c.StoreCellFromObj;
                    return c;
                }
            }

            return null;
        }
    }

    public class QueryContractTechOperations
    {
        public List<ContractTechOperation> querySelectOperations(DateTime date)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {

                    var query = from c in db.ContractTechOperations
                                where c.Date == date
                                select c;

                    return query.ToList();
                }
            }
            return null;
        }

        public List<ContractTechOperation> querySelectOperations()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {

                    var query = from c in db.ContractTechOperations
                                select c;

                    return query.ToList();
                }
            }
            return null;
        }

        public bool queryAddContractTechOperation(ContractTechOperation c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.ContractTechOperations.Add(c);
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

        public bool queryUpdateContractTechOperation(ContractTechOperation c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ContractTechOperation contract = db.ContractTechOperations.Find(c.Id);

                        contract.TechCardId = c.TechCardId;
                        contract.Amount = c.Amount;
                        contract.Date = c.Date;

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

        public bool queryDeleteContractTechOperation(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        ContractTechOperation contract = db.ContractTechOperations.Find(Id);
                        db.ContractTechOperations.Remove(contract);

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

        public ContractTechOperation queryFindContractTechOperationById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 3) //Начальник или Кладовщик
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.ContractTechOperations.Find(Id);
                }
            }
            return null;
        }

    }

}


