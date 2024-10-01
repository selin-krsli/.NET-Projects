using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class MovementController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = dbKutuphane.TBL_HAREKET.Where(s=>s.IslemDurum==false).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET parametre)
        {
            dbKutuphane.TBL_HAREKET.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("OduncVer");
        }
        public ActionResult RefundMovement(int id)
        {
            var value = dbKutuphane.TBL_HAREKET.Find(id);

            DateTime deger1 = DateTime.Parse(value.IadeTarihi.ToString());
            DateTime deger2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan deger3 = deger2-deger1;
            ViewBag.Deger1 = deger3.TotalDays;
            return View(value);
        }
        public ActionResult UpdateRefund(TBL_HAREKET parametre)
        {
            var existingValue = dbKutuphane.TBL_HAREKET.Find(parametre.ID);
            existingValue.UyeGetirTarih = parametre.UyeGetirTarih;
            existingValue.IslemDurum = true;
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}