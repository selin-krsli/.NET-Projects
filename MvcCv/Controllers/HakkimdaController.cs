using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        GenericRepository<TBL_ABOUT> repository = new GenericRepository<TBL_ABOUT>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TBL_ABOUT model)
        {
            TBL_ABOUT entity = repository.Find(s => s.ID == 1);
            entity.Ad = model.Ad;
            entity.Soyad = model.Soyad;
            entity.Adres = model.Adres;
            entity.Telefon = model.Telefon;
            entity.Mail = model.Mail;
            entity.Aciklama = model.Aciklama;
            entity.Resim = model.Resim;
            repository.TUpdate(entity);
            return RedirectToAction("Index");
        }
    }
}