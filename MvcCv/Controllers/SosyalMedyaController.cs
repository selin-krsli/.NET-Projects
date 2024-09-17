using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TBL_SOCIALMEDIA> repository = new GenericRepository<TBL_SOCIALMEDIA>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniSosyalMedya()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSosyalMedya(TBL_SOCIALMEDIA model)
        {
            repository.TAdd(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalMedyaGüncelle(int id)
        {
            var value = repository.Find(s => s.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult SosyalMedyaGüncelle(TBL_SOCIALMEDIA model)
        {
            TBL_SOCIALMEDIA entity = repository.Find(s=>s.ID==model.ID);
            entity.Ad = model.Ad;
            entity.Link = model.Link;
            entity.Ikon = model.Ikon;
            entity.Durum = true;
            repository.TUpdate(entity);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalMedyaSil(int id)
        {
            TBL_SOCIALMEDIA entity = repository.Find(s=> s.ID==id);
            entity.Durum = false;
            repository.TUpdate(entity);
            return RedirectToAction("Index");
        }
    }
}