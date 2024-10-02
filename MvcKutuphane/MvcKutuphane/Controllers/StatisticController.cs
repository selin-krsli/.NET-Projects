using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class StatisticController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var value1 = dbKutuphane.TBL_UYELER.Count();
            var value2 = dbKutuphane.TBL_KITAP.Count();
            var value3 = dbKutuphane.TBL_KITAP.Where(s=>s.Durum==false).Count();
            var value4 = dbKutuphane.TBL_CEZALAR.Sum(s => s.Para);
            ViewBag.deger1=value1;
            ViewBag.deger2=value2;
            ViewBag.deger3=value3;  
            ViewBag.deger4=value4;
            return View();
        }
        public ActionResult Weather()
        {
            return View();
        }
        public ActionResult WeatherCard()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase file)
        {
            if(file.ContentLength > 0)
            {
                string filePath = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(file.FileName));
                file.SaveAs(filePath);
            }
            return RedirectToAction("Galeri");
        }
        public ActionResult LinqCard()
        {
            var value1 = dbKutuphane.TBL_KITAP.Count();
            var value2 = dbKutuphane.TBL_UYELER.Count();
            var value3 = dbKutuphane.TBL_CEZALAR.Sum(s=>s.Para);
            var value4 = dbKutuphane.TBL_KITAP.Where(s=>s.Durum==false).Count();
            var value5 = dbKutuphane.TBL_KATEGORI.Count();
            var value6 = dbKutuphane.EnAktifUye().FirstOrDefault();
            var value7 = dbKutuphane.EnÇokOkunanKitap().FirstOrDefault();
            var value8 = dbKutuphane.EnFazlaKitapYazar().FirstOrDefault();
            var value9 = dbKutuphane.TBL_KITAP.GroupBy(s => s.YayınEvi).OrderByDescending(n => n.Count()).Select(l => new {l.Key}).FirstOrDefault();
            var value10 = dbKutuphane.EnBaşarılıPersonel().FirstOrDefault();
            var value11 = dbKutuphane.TBL_ILETISIM.Count();
            var value12 = dbKutuphane.TBL_HAREKET.Where(s=>s.UyeGetirTarih==DateTime.Now).Count();
            ViewBag.deger1=value1;
            ViewBag.deger2=value2;
            ViewBag.deger3=value3;
            ViewBag.deger4=value4;
            ViewBag.deger5=value5;
            ViewBag.deger6=value6;
            ViewBag.deger7=value7;
            ViewBag.deger8=value8;
            ViewBag.deger9=value9;
            ViewBag.deger10=value10;
            ViewBag.deger11=value11;
            ViewBag.deger12=value12;
            return View();
        }
    }
}