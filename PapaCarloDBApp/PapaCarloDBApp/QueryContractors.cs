using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class QueryContractors
    {
        public List<Contractor> querySelectContractors(int contractorType)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2 || LoginInfo.Position == 3) 
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from c in db.Contractors
                                select c;

                    if (contractorType > 0)
                    {
                        query = from c in db.Contractors
                                where c.Type == contractorType
                                select c;
                    }

                    return query.ToList();
                }

            }
            return null;
        }

        public List<Contractor> querySelectContractorsBySearch(string name)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from c in db.Contractors
                                where c.Name.Contains(name)
                                select c;

                    return query.ToList();
                }

            }
            return null;
        }

        public List<Contractor> querySelectContractorsBySearch(string name, int type)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from c in db.Contractors
                                where (c.Name.Contains(name) &&
                                c.Type==type)
                                select c;

                    return query.ToList();
                }

            }
            return null;
        }

        public bool queryAddContractor(Contractor c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2) //Начальник или бухгалтер
            {

                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        db.Contractors.Add(c);
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

        public bool queryUpdateContractor(Contractor c)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2) //Начальник или бухгалтер
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        Contractor contractor = db.Contractors.Find(c.Id);

                        contractor.Name = c.Name;
                        contractor.Type = c.Type;

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

        public bool queryDeleteContractor(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2) //Начальник или бухгалтер
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        Contractor contractor = db.Contractors.Find(Id);
                        db.Contractors.Remove(contractor);

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

        public Contractor queryFindContractorById(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2) //Начальник или бухгалтер
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    return db.Contractors.Find(Id);
                }
            }
            return null;
        }
    }
}
