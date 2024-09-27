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
            var values = dbKutuphane.TBL_HAREKET.ToList();
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
            return View(value);
        }
    }
}