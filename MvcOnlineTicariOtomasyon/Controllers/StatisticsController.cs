using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var count = c.Carilers.Count().ToString();
            ViewBag.d1=count;
            var numberp=c.Products.Count().ToString();
            ViewBag.d2=numberp;
            var numberpersonel = c.Personels.Count().ToString();
            ViewBag.d3 = numberpersonel;
            var numbercategory = c.Categorys.Count().ToString();
            ViewBag.d4 = numbercategory;
            var numberstock = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = numberstock;
            var numberbrand =(from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = numberbrand;
            var crirtic= c.Products.Count(x=>x.Stock<=20).ToString();
            ViewBag.d7= crirtic;
            var maxprice = (from x in c.Products orderby x.SalesPrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = maxprice;
            var minprice = (from x in c.Products orderby x.SalesPrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = minprice;
            var maxbrand =c.Products.GroupBy(x=>x.Brand).OrderByDescending(c=>c.Count()).Select(x=>x.Key).FirstOrDefault();
            ViewBag.d10 = maxbrand;
            var numref = c.Products.Count(x=>x.ProductName=="Buzdolabı").ToString();
            ViewBag.d11 = numref;
            var numlaptop = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d12 = numlaptop;
            var bestseller= c.Products.Where(x=>x.ProductId ==(c.SalesMoves.GroupBy(a=>a.ProductId).OrderByDescending(z=>z.Count()).Select(y=>y.Key)).FirstOrDefault()).Select(x=>x.ProductName).FirstOrDefault();
            ViewBag.d13= bestseller;
            var total= c.SalesMoves.Sum(x=>x.Amount).ToString();
            ViewBag.d14 = total;
            DateTime today = DateTime.Today ;
            var totalsale= c.SalesMoves.Count(x=> x.Date ==today).ToString();
            ViewBag.d15 = totalsale;
            var todaystotal = 0;
            try
            {
                 todaystotal = (from x in c.SalesMoves where x.Date == today select x.Amount).Sum();
            }
            catch
            {
                 todaystotal = 0;
            }

            
                //c.SalesMoves.Where(a=>a.Date==today).Sum(x => x.Amount).ToString();
            ViewBag.d16 = todaystotal.ToString();
            return View();
        }

        public ActionResult SimpleTables()
        {

            var sorgu = from x in c.Carilers
                        group x by x.CariCity into g
                        select new ClassGrup
                        {
                            City = g.Key,
                            Count = g.Count()
                        };

            return View(sorgu.ToList());
        }
        public PartialViewResult p1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Department.DepartmentName into g
                         select new ClassGrup2
                         {
                             Department = g.Key,
                             Count = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult p2()
        {
            var sorgu2 = c.Carilers.ToList();
            return PartialView(sorgu2);
        }
        public PartialViewResult p3()
        {
            var sorgu2 = c.Products.ToList();
            return PartialView(sorgu2);
        }
        public PartialViewResult p4()
        {
            var sorgu3= from x in c.Products
                         group x by x.Brand into g
                         select new ClassGrup3
                         {
                             Brand = g.Key,
                             Count = g.Count()
                         };
            return PartialView(sorgu3.ToList());
        }
    }
}