using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class StaffController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = dbKutuphane.TBL_PERSONEL.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateStaff()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateStaff(TBL_PERSONEL parametre)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            dbKutuphane.TBL_PERSONEL.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStaff(int id)
        {
            var existingValue = dbKutuphane.TBL_PERSONEL.Find(id);
            dbKutuphane.TBL_PERSONEL.Remove(existingValue);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateStaff(int id)
        {
            var existingValue = dbKutuphane.TBL_PERSONEL.Find(id);
            return View(existingValue);
        }
        [HttpPost]
        public ActionResult UpdateStaff(TBL_PERSONEL parametre)
        {
            var existingValue = dbKutuphane.TBL_PERSONEL.Find(parametre.ID);
            if(existingValue != null)
            {
                existingValue.Personel = parametre.Personel;
                dbKutuphane.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}