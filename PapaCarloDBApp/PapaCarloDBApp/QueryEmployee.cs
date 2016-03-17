using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class QueryEmployee
    {
        public List<EmployeeTable> querySelectEmployees()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var query = from employee in db.Employees
                            join position in db.Positions on employee.PositionId equals position.Id
                            select new { employee, position };
                List<EmployeeTable> emplTable = new List<EmployeeTable>();
    
                foreach (var item in query)
                {
                    emplTable.Add(new EmployeeTable(item.employee, item.position));
                }
                return emplTable;
            }
        }

        public List<EmployeeTable> querySelectEmployees(int PositionId)
        {
            if (PositionId == 0)
            {
                return querySelectEmployees();
            }
            else
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from employee in db.Employees
                                join position in db.Positions on employee.PositionId equals position.Id
                                where employee.PositionId == PositionId
                                select new { employee, position };
                    List<EmployeeTable> emplTable = new List<EmployeeTable>();

                    foreach (var item in query)
                    {
                        emplTable.Add(new EmployeeTable(item.employee, item.position));
                    }
                    return emplTable;
                }
            }
        }

        public List<Position> querySelectPositions()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var query = from position in db.Positions 
                            select position;
                return query.ToList();

            }
        }

        public int queryGetUserByCredentials(string login, string password)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var query = from user in db.Employees
                            where user.Login == login
                            where user.Password == password
                            select user;
                return query.Count();
            }
        }

        public bool queryAddEmployee(Employee empl)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    db.Employees.Add(empl);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;//"You entered wrong data";//e.Message;
                }
                return true; //"Your data successfully added.";
            }
        }

        public bool queryUpdateEmployee(Employee empl)
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                try
                {
                    Employee employee=db.Employees.Find(empl.Id);
  
                    employee.Name = empl.Name;
                    employee.Surname= empl.Surname;
                    employee.Patronymic = empl.Patronymic;
                    employee.Login= empl.Login;
                    employee.Password = empl.Password;
                    employee.PositionId= empl.PositionId;

                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;//"Your data successfully added.";
            }
        }

        public bool queryDeleteEmployee(int Id)
        {
            using (DataBaseContext db = new DataBaseContext())
            {

                try
                {
                    Employee employee = db.Employees.Find(Id);
                    db.Employees.Remove(employee);

                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;//"Your data successfully added.";
            }
        }

    }

}
