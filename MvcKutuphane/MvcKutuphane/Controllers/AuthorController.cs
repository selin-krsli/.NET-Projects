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
            dbKutuphane.TBL_YAZAR.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}