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
    public class TechnologicalCard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual List<ProductTechCard> ProductTechCards { get; set; }
    }

    public class ProductTechCard
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductObj"), Required]
        public int ProductId { get; set; }
        [Required]
        public int Amount{ get; set; }
        [ForeignKey("TechCardObj"), Required]
        public int TechCardId { get; set; }
        public int Type { get; set; } //1 - входящие товары, 2 - исходящие товары

        public virtual Product ProductObj { get; set; }
        public virtual TechnologicalCard TechCardObj { get; set; }
    }
}
