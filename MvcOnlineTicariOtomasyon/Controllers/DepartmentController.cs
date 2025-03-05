using MvcOnlineTicariOtomasyon.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var d = c.Departments.Where(x=>x.Situation==true).ToList();
            return View(d);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(string DepartmentName)
        {
            Department d = new Department();
            d.DepartmentName = DepartmentName;
            d.Situation = true;
            c.Departments.Add(d);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int DepartmentId)
        {
            var deleted = c.Departments.Find(DepartmentId);
            deleted.Situation = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int DepartmentId)
        {
            var d = c.Departments.Find(DepartmentId);

            return View(d);
        }
        [HttpPost]
        public ActionResult Update(Department d )
        {
            var updated = c.Departments.Find(d.DepartmentId);
            updated.DepartmentName = d.DepartmentName;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detail(int DepartmentId)
        {
            var p = c.Personels.Where(x=>x.DepartmentId== DepartmentId).ToList();
            var d = c.Departments.Find(DepartmentId);
            ViewBag.dept = d.DepartmentName;
            return View(p);
        }
        public ActionResult DepartmentPersonelDetail(int PersonelId)
        {
             var s= c.SalesMoves.Where(x=>x.PersonelId== PersonelId).ToList();
            var per = c.Personels.Find(PersonelId);
            ViewBag.deptper = per.PersonelName +" "+ per.PersonelSurname;
            return View(s);
        }
    }
}