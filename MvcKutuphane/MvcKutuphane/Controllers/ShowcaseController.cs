using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class ShowcaseController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();

        [HttpGet]
        public ActionResult Index()
        {
            Class1 example = new Class1();
            example.Deger1 = dbKutuphane.TBL_KITAP.ToList();
            example.Deger2 = dbKutuphane.TBL_HAKKIMIZDA.ToList();
            return View(example);
        }
        [HttpPost]
        public ActionResult Index(TBL_ILETISIM parametre)
        {
            dbKutuphane.TBL_ILETISIM.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}