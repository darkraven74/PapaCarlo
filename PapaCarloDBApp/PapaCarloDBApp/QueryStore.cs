using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class QueryStore
    {
        public List<Storehouse> querySelectStorehouses()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from storehouse in db.Storehouses
                                select storehouse;
                    return query.ToList();

                }
            }
            return null;
        }

        public List<StoreCellTable> querySelectStoreCells(int storehouseId)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from storecell in db.StoreCells
                                join storehouse in db.Storehouses on storecell.StorehouseId equals storehouse.Id
                                select new { storehouse, storecell };

                    if (storehouseId > 0)
                    {
                        query = from storecell in db.StoreCells
                                join storehouse in db.Storehouses on storecell.StorehouseId equals storehouse.Id
                                where storecell.StorehouseId == storehouseId
                                select new { storehouse, storecell };
                    }
                    List<StoreCellTable> table = new List<StoreCellTable>();

                    foreach (var item in query)
                    {
                        table.Add(new StoreCellTable(item.storecell, item.storehouse));
                    }
                    return table;

                }
            }
            return null;
        }

        public bool queryAddStoreCell(StoreCell c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.StoreCells.Add(c);
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

        public bool queryUpdateStoreCell(StoreCell c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        StoreCell p = db.StoreCells.Find(c.Id);

                        p.Description = c.Description;
                        p.StorehouseId = c.StorehouseId;

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

        public bool queryDeleteStoreCell(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        StoreCell p = db.StoreCells.Find(Id);
                        db.StoreCells.Remove(p);

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

        public StoreCell queryFindStoreCellById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.StoreCells.Find(Id);
                }
            }
            return null;
        }

        public bool queryAddStorehouse(Storehouse c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.Storehouses.Add(c);
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

        public bool queryUpdateStorehouse(Storehouse c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        Storehouse p = db.Storehouses.Find(c.Id);

                        p.Name = c.Name;
                        p.Address = c.Address;

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

        public bool queryDeleteStorehouse(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        Storehouse p = db.Storehouses.Find(Id);
                        db.Storehouses.Remove(p);

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

        public Storehouse queryFindStorehouseById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.Storehouses.Find(Id);
                }
            }
            return null;
        }
    }
}
