using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.CargoDetails.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Save()
        {
            Random rnd = new Random();
            string[] caracter = { "A", "B", "C", "D" ,"E","F","G","H","J","K","L","M","N"};
            int k1, k2, k3;
            k1 = rnd.Next(0,caracter.Length);
            k2 = rnd.Next(0, caracter.Length);
            k3 = rnd.Next(0, caracter.Length);
            int s1,s2,s3;
            s1= rnd.Next(100,1000);
            s2= rnd.Next(10,99);
            s3= rnd.Next(10,99);
            string code=s1.ToString() + caracter[k1] + s2.ToString() + caracter[k2] + s3.ToString() + caracter[k3];
            ViewBag.code = code;

            return View();
        }
        [HttpPost]
        public ActionResult Save(CargoDetail cargo)
        {
            
            c.CargoDetails.Add(cargo);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detail(string id)
        {
            var p = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            ViewBag.id = id;
            return View(p);
        }
        public ActionResult Move(string id)
        {
           ViewBag.id = id;
            Session["id"]=id;
            return View();
        }
        [HttpPost]
        public ActionResult Move(CargoTracking t)
        {
            t.TrackingCode = Session["id"].ToString();
            c.CargoTrackings.Add(t);
            c.SaveChanges();
            return RedirectToAction("Detail", "Cargo");
        }
    }
}