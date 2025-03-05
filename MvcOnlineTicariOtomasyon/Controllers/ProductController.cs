using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var products = c.Products.Where(x => x.Situation == true).ToList();
            return View(products);
        }
        [HttpGet]
        public ActionResult Save()
        {
            List<SelectListItem> products = (from x in c.Categorys.ToList() select new SelectListItem
            {
                Text=x.CategoryName,
                Value=x.CategoryId.ToString()
            }).ToList();
            ViewBag.ctg= products;
            return View();
        }
        [HttpPost]
        public ActionResult Save(string PruductName,string Brand, int Stock,decimal Purchaseprice,decimal SalesPrice,bool Situation,string İmage,int categoryid)
        {
            Product product = new Product();
            product.ProductName = PruductName;
            product.Brand = Brand;
            product.Stock = Stock;
            product.Purchaseprice = Purchaseprice;
            product.SalesPrice = SalesPrice;
            product.Situation = Situation;
            product.İmage = İmage;
            product.Category= c.Categorys.Find(categoryid);
            c.Products.Add(product);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int ProductId)
        {
            var deleted = c.Products.Find(ProductId);
            deleted.Situation = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int ProductId)
        {
            var product = c.Products.Find(ProductId);
            List<SelectListItem> products = (from x in c.Categorys.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.ctg = products;
            return View(product);
        }
        [HttpPost]
        public ActionResult Update(Product p)
        {
            var updated = c.Products.Find(p.ProductId);
            updated.ProductName = p.ProductName;
            updated.Brand = p.Brand;
            updated.Stock = p.Stock;
            updated.Purchaseprice = p.Purchaseprice;
            updated.SalesPrice = p.SalesPrice;
            updated.Situation = p.Situation;
            updated.İmage = p.İmage;
            updated.categoryid = p.categoryid;
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult ProductList()
        {
            var product = c.Products.ToList();
            return View (product);
        }
        public ActionResult Sale(int ProductId)
        {
            

            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelName + " " + x.PersonelSurname,
                                                 Value = x.PersonelId.ToString()
                                             }).ToList();
            ViewBag.per = personel;
            var finded = c.Products.Find(ProductId);
            ViewBag.id = finded.ProductId.ToString();
            ViewBag.sprice = finded.SalesPrice;

            return View();
        }
        [HttpPost]
        public ActionResult Sale(SalesMove s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            s.Price = s.Price;
            c.SalesMoves.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index", "Sales");
        }
    }
}