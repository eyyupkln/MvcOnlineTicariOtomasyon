using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.classes
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSerino { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillSırano { get; set; }

        public DateTime  Date { get; set; }
        [Column(TypeName = "char")]
        [StringLength(5)]
        public string  Hour  { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public decimal Total { get; set; }
        public ICollection<BillDetail> BillDetails { get; set; }
    }
}