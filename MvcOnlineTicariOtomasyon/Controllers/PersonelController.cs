using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c= new Context();
        public ActionResult Index()
        {
            var p = c.Personels.ToList();
            return View(p);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult Save()
        {
            List<SelectListItem> dep = (from x in c.Departments.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmentName,
                                                 Value = x.DepartmentId.ToString()
                                             }).ToList();
            ViewBag.dept = dep;
            return View();
        }
        [HttpPost]
        public ActionResult Save(Personel per)
        {
            if (Request.Files.Count>0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string fileextension=Path.GetExtension(Request.Files[0].FileName);
                string path= "~/image/"+filename +fileextension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                per.Personelİmage= "/image/" + filename + fileextension;
            }

            c.Personels.Add(per);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult Update(int PersonelId)
        {
            List<SelectListItem> dep = (from x in c.Departments.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.DepartmentName,
                                            Value = x.DepartmentId.ToString()
                                        }).ToList();
            ViewBag.dept = dep;

            var d = c.Personels.Find(PersonelId);

            return View(d);
        }
        [HttpPost]
        public ActionResult Update(Personel per)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string fileextension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/image/" + filename + fileextension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                per.Personelİmage = "/image/" + filename + fileextension;
            }

            var updated = c.Personels.Find(per.PersonelId);
            updated.PersonelName = per.PersonelName;
            updated.PersonelSurname = per.PersonelSurname;
            updated.Personelİmage = per.Personelİmage;
            updated.DepartmentId = per.DepartmentId;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult PersonDetail()
        {
            var list = c.Personels.ToList();
            return View(list);
        }
        
    }
}