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
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int VendorCode { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }

        public virtual List<ProductTechCard> ProductTechCards { get; set; }
        public virtual List<SupplyProduct> SupplyProducts { get; set; }
        public virtual List<AcceptProduct> AcceptProducts { get; set; }
        public virtual List<ContractMove> ContractMoves { get; set; }
        public virtual List<ContractShipment> ContractShipments { get; set; }
        public virtual List<ReportBalance> ReportBalances { get; set; }
        public virtual List<ReportPredict> ReportPredicts { get; set; }
    }
}
