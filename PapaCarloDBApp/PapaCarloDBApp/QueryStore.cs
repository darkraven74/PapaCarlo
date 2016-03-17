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
            using (DataBaseContext db = new DataBaseContext())
            {
                var query = from storehouse in db.Storehouses
                            select storehouse;
                return query.ToList();

            }
        }

        public List<StoreCellTable> querySelectStoreCells(int storehouseId)
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

        public bool queryAddStoreCell(StoreCell c)
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

        public bool queryUpdateStoreCell(StoreCell c)
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

        public bool queryDeleteStoreCell(int Id)
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

        public StoreCell queryFindStoreCellById(int Id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.StoreCells.Find(Id);
            }
        }

        public bool queryAddStorehouse(Storehouse c)
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

        public bool queryUpdateStorehouse(Storehouse c)
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

        public bool queryDeleteStorehouse(int Id)
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

        public Storehouse queryFindStorehouseById(int Id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.Storehouses.Find(Id);
            }
        }
    }
}
