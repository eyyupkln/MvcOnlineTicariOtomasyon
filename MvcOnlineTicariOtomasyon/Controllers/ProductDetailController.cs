using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context  c = new Context();
        public ActionResult Index(int ProductId)
        {
            var list = c.Products.Where(x=>x.ProductId == ProductId).ToList();
            return View(list);
        }
    }
}