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
        public ActionResult Index(string searchingWord)
        {
            var values = dbKutuphane.TBL_KITAP.ToList();
            if(!String.IsNullOrEmpty(searchingWord))
            {
                values = dbKutuphane.TBL_KITAP
                        .Where(s=>s.Ad.Contains(searchingWord))
                        .ToList();
            }
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
            var author = dbKutuphane.TBL_YAZAR.FirstOrDefault(s=>s.ID==parametre.TBL_YAZAR.ID);
            var category = dbKutuphane.TBL_KATEGORI.FirstOrDefault(n => n.ID == parametre.TBL_KATEGORI.ID);
            parametre.TBL_YAZAR = author;
            parametre.TBL_KATEGORI = category;
            dbKutuphane.TBL_KITAP.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            var existingBook = dbKutuphane.TBL_KITAP.Find(id);
            dbKutuphane.TBL_KITAP.Remove(existingBook);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            List<SelectListItem> value1 = (from s in dbKutuphane.TBL_KATEGORI.ToList() select new SelectListItem { Text= s.Ad, Value=s.ID.ToString()}).ToList();
            ViewBag.Categories = value1;
            List<SelectListItem> value2 = (from n in dbKutuphane.TBL_YAZAR.ToList() select new SelectListItem { Text=n.Ad + "" + n.Soyad, Value=n.ID.ToString()}).ToList();
            ViewBag.Author = value2;
            var existingBook = dbKutuphane.TBL_KITAP.Find(id);
            return View(existingBook);
        }
        [HttpPost]
        public ActionResult UpdateBook(TBL_KITAP parametre)
        {
            var existingBook = dbKutuphane.TBL_KITAP.Find(parametre.ID);
            if (existingBook != null)
            {
                existingBook.Ad = parametre.Ad;
                existingBook.BasımYılı = parametre.BasımYılı;
                existingBook.YayınEvi = parametre.YayınEvi;
                existingBook.Sayfa = parametre.Sayfa;
                var category = dbKutuphane.TBL_KATEGORI.Where(s=>s.ID==parametre.TBL_KATEGORI.ID).FirstOrDefault();
                var author = dbKutuphane.TBL_YAZAR.Where(n=>n.ID==parametre.TBL_YAZAR.ID).FirstOrDefault();
                existingBook.Kategori = category.ID;
                existingBook.Yazar = author.ID;
                dbKutuphane.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}