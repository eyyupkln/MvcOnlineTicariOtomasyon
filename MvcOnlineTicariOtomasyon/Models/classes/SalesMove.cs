using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.classes
{
    public class SalesMove
    {
        [Key]
        public int SalesMoveId { get; set; }
        
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}