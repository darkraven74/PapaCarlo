using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PapaCarloDBApp
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [ForeignKey("PositionObj"), Required]
        public int PositionId { get; set; }

        public virtual Position PositionObj { get; set; }
        public virtual List<EmployeeRight> EmployeeRights { get; set; }
    }

    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual List<Employee> Employees { get; set; }
    }

    public class EmployeeRight
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EmployeeObj"), Required]
        public int EmployeeId { get; set; }
        [Required]
        public int Type { get; set; } //1-просмотр, 2-редактирование, 3-добавление

        public virtual Employee EmployeeObj { get; set; }
    }


}
