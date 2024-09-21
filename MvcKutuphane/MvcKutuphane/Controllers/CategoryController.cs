using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class CategoryController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = dbKutuphane.TBL_KATEGORI.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(TBL_KATEGORI parametre)
        {
            dbKutuphane.TBL_KATEGORI.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = dbKutuphane.TBL_KATEGORI.Find(id);
            dbKutuphane.TBL_KATEGORI.Remove(value);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = dbKutuphane.TBL_KATEGORI.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(TBL_KATEGORI parametre)
        {
            var value = dbKutuphane.TBL_KATEGORI.Find(parametre.ID);
            value.Ad = parametre.Ad;
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}