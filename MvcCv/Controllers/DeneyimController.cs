using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        DeneyimRepository repo = new DeneyimRepository();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(TBL_EXPERIENCE model)
        {
            repo.TAdd(model);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            TBL_EXPERIENCE entity = repo.Find(s=>s.ID == id);
            repo.TDelete(entity);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            TBL_EXPERIENCE entity = repo.Find(s=>s.ID == id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(TBL_EXPERIENCE model)
        {
            TBL_EXPERIENCE entity = repo.Find(s => s.ID == model.ID);
            entity.Baslik = model.Baslik;
            entity.AltBaslik = model.AltBaslik;
            entity.Tarih = model.Tarih;
            entity.Aciklama = model.Aciklama;
            repo.TUpdate(entity);
            return RedirectToAction("Index");
        }
    }
}