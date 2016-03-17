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
            using (DataBaseContext db = new DataBaseContext())
            {
                var query = from product in db.Products
                            select product;
                return query.ToList();

            }
        }

        public List<string> querySelectAllColors()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var query = from product in db.Products
                            select product.Color;
                return query.Distinct().ToList();
            }
        }

        public List<Product> querySelectProducts(string color)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var query = from product in db.Products
                            where product.Color.Equals(color)
                            select product;
                return query.ToList();

            }
        }

        public bool queryAddProduct(Product c)
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

        public bool queryUpdateProduct(Product c)
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

        public bool queryDeleteProduct(int Id)
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

        public Product queryFindProductById(int Id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.Products.Find(Id);
            }
        }
    }
}
