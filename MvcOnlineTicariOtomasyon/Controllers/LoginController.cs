using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public PartialViewResult p1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult p1(Cariler cari)
        {
            c.Carilers.Add(cari);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult p2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult p2(Cariler cari)
        {
            var login= c.Carilers.FirstOrDefault(x=>x.CariMail==cari.CariMail && x.CariPassword==cari.CariPassword);
            if (login!=null)
            {
                FormsAuthentication.SetAuthCookie(login.CariMail,false);
                Session["CariMail"]=login.CariMail;
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var login = c.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.UserName, false);
                Session["UserName"] = login.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}