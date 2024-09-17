using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TBL_INTERESTS> repository = new GenericRepository<TBL_INTERESTS>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(TBL_INTERESTS model)
        {
            TBL_INTERESTS entity = repository.Find(s=>s.ID == 1);
            entity.Aciklama1 = model.Aciklama1;
            entity.Aciklama2 = model.Aciklama2;
            repository.TUpdate(entity);
            return RedirectToAction("Index");
        }
    }
}