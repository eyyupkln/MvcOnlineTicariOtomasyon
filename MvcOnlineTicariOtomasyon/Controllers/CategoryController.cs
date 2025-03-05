using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.classes;  

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            List<Category> category = c.Categorys.ToList();
            return View(category);
        }
        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(string CategoryName)
        {
            Category category = new Category();
            category.CategoryName = CategoryName;
            c.Categorys.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int CategoryId)
        {
            var category = c.Categorys.Find(CategoryId);

            return View(category);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            var updated = c.Categorys.Find(category.CategoryId);
            updated.CategoryName = category.CategoryName;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int CategoryId)
        {
            var deleted=c.Categorys.Find(CategoryId);
            c.Categorys.Remove(deleted);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}