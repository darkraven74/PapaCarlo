using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PapaCarloDBApp
{
    public class Query
    {
        public List<EmployeeTable> querySelectEmployees()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var query = from employee in db.Employees
                            join position in db.Positions on employee.PositionId equals position.Id
                            select new { employee, position };
                List<EmployeeTable> emplTable = new List<EmployeeTable>();
                //            //select position;
                //DataTable dt = query.CopyToDataTable();
                // query.SelectMany(<Employee>);
                foreach (var item in query)
                {
                    emplTable.Add(new EmployeeTable(item.employee, item.position));//Console.WriteLine("{0} {1} {2}", item.employee.Name, item.employee.Login, item.position.Name );
                }
                return emplTable;
            }
        }

        static void Main(string[] args)
        {
            Query pr = new Query();

           foreach (var item in pr.querySelectEmployees())
            {
                Console.WriteLine("{0} {1}", item.employee.Name, item.position.Name);
            }
           Console.ReadLine();
           /* using (DataBaseContext db = new DataBaseContext())
            {

                Employee e1 = new Employee { Login = "mary", Name = "Mary", Surname = "F", Password = "2101", PositionId = 1 };
                Employee e2 = new Employee { Login = "vlad", Name = "Vlad", Surname = "Siv", Password = "0608", PositionId = 2 };
                Employee e3 = new Employee { Login = "alex", Name = "Alex", Surname = "Pug", Password = "1301", PositionId = 3 };

                db.Employees.AddRange(new List<Employee> { e1, e2, e3 });

                db.SaveChanges();*/
                /* Position p1 = new Position { Name = "Начальник склада" };
                Position p2 = new Position { Name = "Бухгалтер" };
                Position p3 = new Position { Name = "Кладовщик" };

                db.Positions.Add(p1);
                db.Positions.Add(p2);
                db.Positions.Add(p3);

                db.SaveChanges();
            }*/
        }
    }
}
