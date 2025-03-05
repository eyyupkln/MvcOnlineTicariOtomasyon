using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();
        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var list = c.Messagess.Where(x=>x.Receiver == mail).ToList();

            ViewBag.m=mail;

           

            var mailid= c.Carilers.Where(x=>x.CariMail==mail).Select(y=>y.CariId).FirstOrDefault();
            ViewBag.mailid=mailid;

            var totalsale=c.SalesMoves.Where(x=>x.CariId==mailid).Count();
            ViewBag.totalsale=totalsale;
            var totalpayment = 0;
            try
            {
                totalpayment = c.SalesMoves.Where(x => x.CariId == mailid).Sum(y => y.Amount);
            }
            catch (Exception)
            {
                totalpayment = 0;
            }

            
            ViewBag.totalpayment=totalpayment;

            var totalquantity = 0;
            try
            {
                totalquantity = c.SalesMoves.Where(x => x.CariId == mailid).Sum(y => y.Quantity);
            }
            catch (Exception)
            {
                totalquantity = 0;
            }
            ViewBag.totalquantity=totalquantity;

            var namesurname = c.Carilers.Where(x => x.CariId == mailid).Select(y=>y.CariName +" " + y.CariSurname).FirstOrDefault();
            ViewBag.namesurname=namesurname;

            var city=c.Carilers.Where(x=>x.CariId==mailid).Select(y=>y.CariCity).FirstOrDefault();
            ViewBag.city=city;
            return View(list);
        }
        [Authorize]
        public ActionResult Orders()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x=>x.CariMail ==mail.ToString()).Select(y=>y.CariId).FirstOrDefault();
            var list = c.SalesMoves.Where(x => x.CariId == id).ToList();
            return View(list);
        }
        [Authorize]
        public ActionResult İncomingMessage()
        {
            var mail = (string)Session["CariMail"];
            var list =c.Messagess.Where(x=>x.Receiver==mail).OrderByDescending(x=>x.MessageId).ToList();
            var gelen= c.Messagess.Count(c=>c.Receiver==mail);
            ViewBag.gelen = gelen;
            var giden = c.Messagess.Count(c => c.Sender == mail);
            ViewBag.giden = giden;
            return View(list);
        }
        [Authorize]
        public ActionResult SendedMessages()
        {
            var mail = (string)Session["CariMail"];
            var list = c.Messagess.Where(x => x.Sender == mail).OrderByDescending(x => x.MessageId).ToList();
            var giden = c.Messagess.Count(c => c.Sender == mail);
            ViewBag.giden = giden;
            var gelen = c.Messagess.Count(c => c.Receiver == mail);
            ViewBag.gelen = gelen;
            return View(list);
        }
        [Authorize]
        public ActionResult MessageDetail(int MessageId)
        {
            var mail = (string)Session["CariMail"];
            var giden = c.Messagess.Count(c => c.Sender == mail);
            ViewBag.giden = giden;
            var gelen = c.Messagess.Count(c => c.Receiver == mail);
            ViewBag.gelen = gelen;

            var list = c.Messagess.Where(x=>x.MessageId == MessageId).ToList();
            return View(list);
        }
        [Authorize]
        [HttpGet]

        public ActionResult NewMessage()
        {
            var mail = (string)Session["CariMail"];
            var giden = c.Messagess.Count(c => c.Sender == mail);
            ViewBag.giden = giden;
            var gelen = c.Messagess.Count(c => c.Receiver == mail);
            ViewBag.gelen = gelen;
            ViewBag.mail= mail;
            return View();
        }
        [Authorize]
        [HttpPost]

        public ActionResult NewMessage(Messages m)
        {
            var mail = (string)Session["CariMail"];
            m.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Sender = mail;

            c.Messagess.Add(m);
            c.SaveChanges();

            return View();
        }
        [Authorize]
        public ActionResult CargoTracking(string p)
        {
            var k = from x in c.CargoDetails select x;
                k=k.Where(y=>y.Code.Contains(p));
            return View(k.ToList());
        }
        [Authorize]
        public ActionResult CargoDetail(string id)
        {
            var p = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            ViewBag.id = id;
            return View(p);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }

        public PartialViewResult p1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            var caribul=c.Carilers.Find(id);
            return PartialView("p1",caribul);
        }

        public PartialViewResult p2()
        {
            var list = c.Messagess.Where(x=>x.Sender=="admin").ToList();
            return PartialView(list);
        }
        public ActionResult Update(Cariler cari)
        {
            var updated = c.Carilers.Find(cari.CariId);
            updated.CariName = cari.CariName;
            updated.CariSurname = cari.CariSurname;
            updated.CariCity = cari.CariCity;
            updated.CariMail = cari.CariMail;
            updated.CariPassword = cari.CariPassword;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}