﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PapaCarloDBApp
{
    public class QueryEmployee
    {
        public List<EmployeeTable> querySelectEmployees()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2) //Начальник склада, Бухгалтер  
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
            return null;
        }

        public List<EmployeeTable> querySelectEmployees(int PositionId)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
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
            return null;
        }

        public List<EmployeeTable> querySelectEmployeesBySearch(string surname, string name, string patronymic)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
               
                    using (DataBaseContext db = new DataBaseContext())
                    {
                        var query = from employee in db.Employees
                                    join position in db.Positions on employee.PositionId equals position.Id
                                    where (employee.Surname.Contains(surname) &&
                                    employee.Name.Contains(name) &&
                                    employee.Patronymic.Contains(patronymic))
                                    select new { employee, position };
                        List<EmployeeTable> emplTable = new List<EmployeeTable>();

                        foreach (var item in query)
                        {
                            emplTable.Add(new EmployeeTable(item.employee, item.position));
                        }
                        return emplTable;
                    }
                
            }
            return null;
        }

        public List<Position> querySelectPositions()
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from position in db.Positions
                                select position;
                    return query.ToList();

                }
            }
            return null;
        }

        public List<Employee> queryGetUserByCredentials(string login, string password)
        {
            using (DataBaseContext db = new DataBaseContext())
                {
                    var query = from user in db.Employees
                                where user.Login == login
                                where user.Password == password
                                select user;
                    return query.ToList();
                }
        }

        public bool queryAddEmployee(Employee empl)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
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
            return false;
        }

        public bool queryUpdateEmployee(Employee empl)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
            {
                using (DataBaseContext db = new DataBaseContext())
                {
                    try
                    {
                        Employee employee = db.Employees.Find(empl.Id);

                        employee.Name = empl.Name;
                        employee.Surname = empl.Surname;
                        employee.Patronymic = empl.Patronymic;
                        employee.Login = empl.Login;
                        employee.Password = empl.Password;
                        employee.PositionId = empl.PositionId;

                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                    return true;//"Your data successfully added.";
                }
            }
            return false;
        }

        public bool queryDeleteEmployee(int Id)
        {
            if (LoginInfo.Position == 1 || LoginInfo.Position == 2)//Начальник склада, Бухгалтер  
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
            return false;

        }
    }

}
