using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        public ActionResult Index()
        {
            var user = Session["UserName"];
            var list = c.Admins.FirstOrDefault(x => x.UserName == user.ToString());
            return View(list);
        }
        
        public ActionResult Save(Admin a)
        {
            var user = Session["UserName"];
            var list = c.Admins.FirstOrDefault(x => x.UserName == user.ToString());
            list.UserName= a.UserName;
            list.Password= a.Password;
            c.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }
    }
}