using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        CVDBEntities db = new CVDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_ABOUT.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.TBL_SOCIALMEDIA.Where(s=>s.Durum==true).ToList();
            return PartialView(sosyalMedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TBL_EXPERIENCE.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitim()
        {
            var egitimlerim = db.TBL_EDUCATION.ToList();
            return PartialView(egitimlerim);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim = db.TBL_SKILLS.ToList();
            return PartialView(yeteneklerim);
        }
        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.TBL_INTERESTS.ToList();
            return PartialView(hobilerim);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar = db.TBL_AWARDS.ToList();
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult İletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult İletisim(TBL_CONTACT contactModel)
        {
            contactModel.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_CONTACT.Add(contactModel); //db burada modelimize ulaştığımız nesnemizin ismi.
            db.SaveChanges();
            return PartialView();
        }
    }
}