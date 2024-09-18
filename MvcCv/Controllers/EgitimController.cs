using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepository<TBL_EDUCATION> repo = new GenericRepository<TBL_EDUCATION>();
        [Authorize]
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TBL_EDUCATION model)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(model);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var value = repo.Find(s=>s.ID == id);
            repo.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGüncelle(int id)
        {
            var value = repo.Find(s=>s.ID == id);
            return View(value) ;
        }
        [HttpPost]
        public ActionResult EgitimGüncelle(TBL_EDUCATION model)
        {
            if(!ModelState.IsValid)
            {
                return View("EgitimGüncelle");
            }
            var value = repo.Find(s => s.ID == model.ID);
            value.Baslik = model.Baslik;
            value.AltBaslik1 = model.AltBaslik1;
            value.AltBaslik2 = model.AltBaslik2;
            value.GNO = model.GNO;
            value.Tarih = model.Tarih;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}