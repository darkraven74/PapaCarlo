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
    public class ReportBalance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("StoreCellObj"), Required]
        public int StoreCellId { get; set; }
        [ForeignKey("ProductObj"), Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }

        public virtual StoreCell StoreCellObj { get; set; }
        public virtual Product ProductObj { get; set; }
    }

    public class ReportPredict
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("StorehouseObj"), Required]
        public int StorehouseId { get; set; }
        [ForeignKey("ContractSupplyObj"), Required]
        public int ContractSupplyId { get; set; }
        [ForeignKey("ProductObj"), Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int Predict { get; set; }

        public virtual Storehouse StorehouseObj { get; set; }
        public virtual Product ProductObj { get; set; }
        public virtual ContractSupply ContractSupplyObj { get; set; }
    }
}
