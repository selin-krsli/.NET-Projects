using MvcKutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class MemberController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index(int page = 1)//sayfalama işleminin kaçtan başlayacağı anlamına geliyor.
        {
            var values = dbKutuphane.TBL_UYELER.ToList().ToPagedList(page, 3);
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMember(TBL_UYELER parametre)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            dbKutuphane.TBL_UYELER.Add(parametre);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMember(int id)
        {
            var existingValue = dbKutuphane.TBL_UYELER.Find(id);
            dbKutuphane.TBL_UYELER.Remove(existingValue);
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateMember(int id)
        {
            var existingValue = dbKutuphane.TBL_UYELER.Find(id);
            return View(existingValue);
        }
        [HttpPost]
        public ActionResult UpdateMember(TBL_UYELER parametre)
        {
            var existingValue = dbKutuphane.TBL_UYELER.Find(parametre.ID);
            if(existingValue != null)
            {
                existingValue.Ad = parametre.Ad;
                existingValue.Soyad = parametre.Soyad;
                existingValue.Mail = parametre.Mail;
                existingValue.KullaniciAdi = parametre.KullaniciAdi;
                existingValue.Sifre = parametre.Sifre;
                existingValue.Fotograf = parametre.Fotograf;
                existingValue.Telefon = parametre.Telefon;
                existingValue.Okul = parametre.Okul;
                dbKutuphane.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}