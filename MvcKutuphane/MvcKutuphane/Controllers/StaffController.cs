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
            dbKutuphane.TBL_PERSONEL.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}