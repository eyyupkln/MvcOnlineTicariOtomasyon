using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.classes
{
    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(200)]

        public string  Description  { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Code { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]

        public string Personel  { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Receipent { get; set; }
        public DateTime Date { get; set; }
    }
}