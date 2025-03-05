using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.classes
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSurname { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariCity { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariPassword { get; set; }
        public bool Situation { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }


    }
}