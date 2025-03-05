using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;
using Context = MvcOnlineTicariOtomasyon.Models.classes.Context;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cari = c.Carilers.Where(x => x.Situation == true).ToList();
            return View(cari);
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save( string CariName, string CariSurname, string CariCity ,string CariMail)
        {
            Cariler cari = new Cariler();
            cari.CariName = CariName;
            cari.CariSurname = CariSurname;
            cari.CariCity = CariCity;
            cari.CariMail=CariMail;
            cari.Situation = true;
            c.Carilers.Add(cari);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int CariId)
        {
            var deleted = c.Carilers.Find(CariId);
            deleted.Situation = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int CariId)
        {
            var d = c.Carilers.Find(CariId);

            return View(d);
        }
        [HttpPost]
        public ActionResult Update(Cariler cari)
        {
            var updated = c.Carilers.Find(cari.CariId);
            updated.CariName = cari.CariName;
            updated.CariSurname = cari.CariSurname;
            updated.CariCity = cari.CariCity;
            updated.CariMail = cari.CariMail;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
       
        public ActionResult SalesHistory(int CariId)
        {
            var s = c.SalesMoves.Where(x => x.CariId == CariId).ToList();
            var per = c.Carilers.Find(CariId);
            ViewBag.cari = per.CariName + " " + per.CariSurname;
            return View(s);
        }

    }
}