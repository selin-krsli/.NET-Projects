using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();

        [Authorize]
        public ActionResult Index()
        {
            var kullaniciMail = (string)Session["Mail"];
            var values = dbKutuphane.TBL_UYELER.FirstOrDefault(s=>s.Mail==kullaniciMail);
            return View(values);
        }
        [HttpPost]
        public ActionResult Index2(TBL_UYELER parametre)
        {
            var kullanici = (string)Session["Mail"];
            var member = dbKutuphane.TBL_UYELER.FirstOrDefault(s => s.Mail == kullanici);
            member.Sifre = parametre.Sifre;
            member.Ad = parametre.Ad;
            member.Soyad = parametre.Soyad;
            member.Fotograf = parametre.Fotograf;
            member.Okul = parametre.Okul;
            member.KullaniciAdi = parametre.KullaniciAdi;
            dbKutuphane.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}