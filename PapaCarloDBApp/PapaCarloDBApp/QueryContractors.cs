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

        public bool queryAddContractor(Contractor c)
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

        public bool queryUpdateContractor(Contractor c)
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

        public bool queryDeleteContractor(int Id)
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

        public Contractor queryFindContractorById(int Id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                return db.Contractors.Find(Id);
            }
        }
    }
}
