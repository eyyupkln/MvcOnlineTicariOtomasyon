using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public int Stock { get; set; }
        public decimal  Purchaseprice   { get; set; }
        public decimal SalesPrice   { get; set; }
        public bool Situation { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string İmage { get; set; }
        public int categoryid { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }

    }
}