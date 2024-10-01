using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class StatisticController : Controller
    {
        public ActionResult Index()
        {
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
    }
}