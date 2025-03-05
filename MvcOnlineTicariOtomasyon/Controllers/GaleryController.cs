using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GaleryController : Controller
    {
        // GET: Galery
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Products.ToList();
            return View(list);
        }
        public ActionResult Index2()
        {
            var list = c.Products.ToList();
            return View(list);
        }
    }
}