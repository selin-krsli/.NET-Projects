using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<TBL_ADMIN> repository = new GenericRepository<TBL_ADMIN>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AdminEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminEkle(TBL_ADMIN parametre)
        {
            repository.TAdd(parametre);
            return RedirectToAction("Index");
        }

        public ActionResult AdminSil(int id)
        {
            var value = repository.Find(s=>s.ID == id);
            repository.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AdminGüncelle(int id)
        {
            var value = repository.Find(s=>s.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult AdminGüncelle(TBL_ADMIN parametre)
        {
            var value = repository.Find(s=>s.ID==parametre.ID);
            value.KullaniciAdi = parametre.KullaniciAdi;
            value.Sifre = parametre.Sifre;
            repository.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}