using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var x = c.SalesMoves.ToList();
            return View(x);
        }
        [HttpGet]
        public ActionResult Save()
        {
            List<SelectListItem> products = (from x in c.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName + "(" + x.Brand + ")",
                                                 Value = x.ProductId.ToString()
                                             }).ToList();
            ViewBag.p = products;

            List<SelectListItem> cari = (from x in c.Carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariName + " " + x.CariSurname,
                                             Value = x.CariId.ToString()
                                         }).ToList();
            ViewBag.c = cari;

            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelName + " " + x.PersonelSurname,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();
            ViewBag.per = personel;
            return View();
        }
        [HttpPost]
        public ActionResult Save(SalesMove s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMoves.Add(s);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int SalesMoveId)
        {
            var d = c.SalesMoves.Find(SalesMoveId);
            List<SelectListItem> products = (from x in c.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName + "(" + x.Brand + ")",
                                                 Value = x.ProductId.ToString()
                                             }).ToList();
            ViewBag.p = products;

            List<SelectListItem> cari = (from x in c.Carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariName + " " + x.CariSurname,
                                             Value = x.CariId.ToString()
                                         }).ToList();
            ViewBag.c = cari;

            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelName + " " + x.PersonelSurname,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();
            ViewBag.per = personel;
            return View(d);
        }
        [HttpPost]
        public ActionResult Update(SalesMove s)
        {
            var updated = c.SalesMoves.Find(s.SalesMoveId);
            updated.ProductId = s.ProductId;
            updated.CariId = s.CariId;
            updated.PersonelId = s.PersonelId;
            updated.Price = s.Price;
            updated.Quantity = s.Quantity;
            updated.Amount = s.Amount;
            updated.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SalesDetail(int SalesMoveId)
        {
            var s = c.SalesMoves.Where(x => x.SalesMoveId == SalesMoveId).ToList();
            return View(s);
        }
        public ActionResult Salesprint()
        {
            var s = c.SalesMoves.ToList();
            return View(s);
        }

    }
}