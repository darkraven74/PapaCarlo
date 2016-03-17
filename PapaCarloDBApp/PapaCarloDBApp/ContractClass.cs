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
    public class ContractSupply //Договор о поставке
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("ContractorObj"), Required]
        public int ContractorId { get; set; }
        public bool wasReceived{ get; set; }
        public int numberOfSupply { get; set; }

        public virtual Contractor ContractorObj { get; set; }
        public virtual List<SupplyProduct> SupplyProducts { get; set; }
    }

    public class SupplyProduct
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductObj"), Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [ForeignKey("ContractSupplyObj"), Required]
        public int ContractSupplyId { get; set; }

        public virtual Product ProductObj { get; set; }
        public virtual ContractSupply ContractSupplyObj { get; set; }
    }

    public class ContractAccept //Договор о приемке
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("ContractSupplyObj"), Required]
        public int ContractSupplyId { get; set; }

        public virtual ContractSupply ContractSupplyObj { get; set; }
        public virtual List<AcceptProduct> AcceptProducts { get; set; }
    }

    public class AcceptProduct
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductObj"), Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }
        [ForeignKey("ContractAcceptObj"), Required]
        public int ContractAcceptId { get; set; }

        public virtual Product ProductObj { get; set; }
        public virtual ContractAccept ContractAcceptObj { get; set; }
    }

    public class ContractMove //Договор о перемещении
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("StoreCellFromObj")]
        public int StoreCellFromId { get; set; }
        [ForeignKey("StoreCellToObj")]
        public int StoreCellToId { get; set; }
        [ForeignKey("ProductObj"), Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }

        public virtual StoreCell StoreCellToObj { get; set; }
        public virtual StoreCell StoreCellFromObj { get; set; }
        public virtual Product ProductObj { get; set; }
       
    }

    public class ContractShipment//Договор об отгрузке
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("StoreCellFromObj"), Required]
        public int StoreCellFromId { get; set; }
        [ForeignKey("ProductObj"), Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }

        public virtual StoreCell StoreCellFromObj { get; set; }
        public virtual Product ProductObj { get; set; }

    }

    public class ContractTechOperation //Технологические операции
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey("TechCardObj"), Required]
        public int TechCardId { get; set; }
        public int Amount { get; set; }

        public virtual TechnologicalCard TechCardObj { get; set; }
    }
}
