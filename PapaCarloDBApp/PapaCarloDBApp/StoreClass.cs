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
    public class Storehouse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual List<StoreCell> StoreCells { get; set; }
    }

    public class StoreCell
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("StorehouseObj"), Required]
        public int StorehouseId { get; set; }
        public string Description { get; set; }

        public virtual Storehouse StorehouseObj { get; set; }
    }
}
