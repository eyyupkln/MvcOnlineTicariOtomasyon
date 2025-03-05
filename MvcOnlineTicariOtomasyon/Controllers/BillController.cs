using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        Context c = new Context();
        public ActionResult Index()
        {
            var bill = c.Bills.ToList();
            return View(bill);
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(string BillSerino,string BillSırano,DateTime Date, string Hour,string VergiDairesi,string TeslimEden,string TeslimAlan)
        {
           Bill b = new Bill();
            b.BillSerino = BillSerino;
            b.BillSırano= BillSırano;
            b.Date = Date;
            b.Hour = Hour;
            b.VergiDairesi = VergiDairesi;
            b.TeslimEden = TeslimEden;
            b.TeslimAlan= TeslimAlan;
            c.Bills.Add(b);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int BillId)
        {
            var bill = c.Bills.Find(BillId);
            return View(bill);
        }
        [HttpPost]
        public ActionResult Update(Bill b)
        {
            var bill = c.Bills.Find(b.BillId);
            bill.BillId = b.BillId;
            bill.BillSerino = b.BillSerino;
            bill.BillSırano= b.BillSırano;
            bill.Date = b.Date;
            bill.Hour = b.Hour;
            bill.VergiDairesi= b.VergiDairesi;
            bill.TeslimEden= b.TeslimEden;
            bill.TeslimAlan = b.TeslimAlan;

            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Detail(int BillId)
        {
            var p = c.BillDetails.Where(x => x.BillId == BillId).ToList();
            var per = c.Bills.Find(BillId);
            ViewBag.id=per.BillId;
            ViewBag.serino = per.BillSerino + per.BillSırano;
            return View(p);
        }
        [HttpGet]
        public ActionResult AddDetail(int BillId)
        {
            var b = c.BillDetails.Where(x=> x.BillId==BillId).FirstOrDefault();
            return View(b);
        }
        [HttpPost]
        public ActionResult AddDetail(BillDetail b)
        {
            c.BillDetails.Add(b);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Dynamic()
        {
            ClassGroup4 cs = new ClassGroup4();
            cs.değer1 = c.Bills.ToList();
            cs.değer2=c.BillDetails.ToList();
            return View(cs);
        }

        public ActionResult Dsave(string BillSerino,string BillSırano,DateTime Date, string VergiDairesi,string Hour, string TeslimEden, string TeslimAlan,string Total, BillDetail[] details)
        {
            Bill b = new Bill();
            b.BillSerino=BillSerino;
            b.BillSırano = BillSırano;
            b.Date=Date;
            b.VergiDairesi=VergiDairesi;
            b.Hour=Hour;
            b.TeslimAlan=TeslimAlan;
            b.TeslimEden=TeslimEden;
            b.Total=decimal.Parse(Total);
            c.Bills.Add(b);
            
            foreach (var item in details)
            {
                BillDetail detail = new BillDetail();
               detail.Description=item.Description;
                detail.Quantity=item.Quantity;
                detail.UnitPrice=item.UnitPrice;
                detail.BillId=item.BillDetailId;
                detail.Amount=item.Amount;
                c.BillDetails.Add(detail);
            }
            c.SaveChanges();
            return Json("Succes",JsonRequestBehavior.AllowGet);
        }
    }
}