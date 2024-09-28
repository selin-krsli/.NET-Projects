using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class AuthorController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = dbKutuphane.TBL_YAZAR.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAuthor(TBL_YAZAR parametre)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            dbKutuphane.TBL_YAZAR.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAuthor(int id)
        {
            var value = dbKutuphane.TBL_YAZAR.Find(id);
            dbKutuphane.TBL_YAZAR.Remove(value);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            var existingAuthor = dbKutuphane.TBL_YAZAR.Find(id);
            return View(existingAuthor);
        }
        [HttpPost]
        public ActionResult UpdateAuthor(TBL_YAZAR parametre)
        {
            var existingAuthor = dbKutuphane.TBL_YAZAR.Find(parametre.ID);
            if(existingAuthor != null)
            {
                existingAuthor.Ad = parametre.Ad;
                existingAuthor.Soyad = parametre.Soyad;
                existingAuthor.Detay = parametre.Detay;
                dbKutuphane.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}