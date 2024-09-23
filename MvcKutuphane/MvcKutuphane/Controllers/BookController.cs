using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class BookController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var values = dbKutuphane.TBL_KITAP.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateBook()
        {
            List<SelectListItem> value1 = (from s in dbKutuphane.TBL_KATEGORI.ToList()
                                           select new SelectListItem
                                            {
                                                 Text=s.Ad,
                                                 Value=s.ID.ToString(),
                                            }).ToList();
            ViewBag.Categories = value1;
            List<SelectListItem> value2 = (from n in dbKutuphane.TBL_YAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text=n.Ad +" "+ n.Soyad ,
                                               Value=n.ID.ToString(),
                                           }).ToList() ;
            ViewBag.Author = value2;
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(TBL_KITAP parametre)
        {
            dbKutuphane.TBL_KITAP.Add(parametre);
            return RedirectToAction("Index");
        }
    }
}