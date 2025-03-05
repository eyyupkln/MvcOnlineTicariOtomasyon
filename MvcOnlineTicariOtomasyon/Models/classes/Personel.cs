using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.classes
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelSurname   { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string Personelİmage { get; set; }
        public ICollection<SalesMove> SalesMoves { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }

}