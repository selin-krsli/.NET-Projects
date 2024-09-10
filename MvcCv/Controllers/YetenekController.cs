using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        GenericRepository<TBL_SKILLS> repo = new GenericRepository<TBL_SKILLS>();
        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBL_SKILLS model)
        {
            repo.TAdd(model);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var value = repo.Find(s => s.ID == id);
            repo.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekGüncelle(int id)
        {
            var value = repo.Find(s=>s.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult YetenekGüncelle(TBL_SKILLS model)
        {
            var value = repo.Find(s=>s.ID==model.ID);
            value.Yetenek = model.Yetenek;
            value.Oran = model.Oran;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}