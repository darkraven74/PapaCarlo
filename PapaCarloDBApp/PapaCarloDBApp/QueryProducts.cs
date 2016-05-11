using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class QueryProducts
    {
        public List<Product> querySelectProducts()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from product in db.Products
                                select product;
                    return query.ToList();

                }
            }
            return null;
        }

        public List<string> querySelectAllColors()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from product in db.Products
                                select product.Color;
                    return query.Distinct().ToList();
                }
            }
            return null;
        }

        public List<Product> querySelectProducts(string color)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {

                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from product in db.Products
                                where product.Color.Equals(color)
                                select product;
                    return query.ToList();

                }
            }
            return null;
        }

        public bool queryAddProduct(Product c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.Products.Add(c);
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

        public bool queryUpdateProduct(Product c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        Product p = db.Products.Find(c.Id);

                        p.Name = c.Name;
                        p.VendorCode = c.VendorCode;
                        p.Color = c.Color;
                        p.Description = c.Description;

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

        public bool queryDeleteProduct(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        Product p = db.Products.Find(Id);
                        db.Products.Remove(p);

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

        public Product queryFindProductById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3)
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.Products.Find(Id);
                }
            }
            return null;
        }
    }
}
