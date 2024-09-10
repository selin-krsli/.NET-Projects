using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        GenericRepository<TBL_AWARDS> repository = new GenericRepository<TBL_AWARDS>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult SertifikaGüncelle(int id)
        {
            var value = repository.Find(s=>s.ID == id);
            ViewBag.ID = id;
            return View(value);
        }
        [HttpPost]
        public ActionResult SertifikaGüncelle(TBL_AWARDS model)
        {
            var value = repository.Find(s => s.ID == model.ID);
            value.Aciklama = model.Aciklama;
            value.Tarih = model.Tarih;
            repository.TUpdate(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SertifikaEkle ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SertifikaEkle(TBL_AWARDS model)
        {
            repository.TAdd(model);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {   
            var value = repository.Find(s=> s.ID == id);
            repository.TDelete(value);
            return RedirectToAction("Index"); 
        }
    }
}