using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MessageController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyeMail = (string)Session["Mail"].ToString();
            var messages = dbKutuphane.TBL_MESAJLAR.Where(s => s.Alici==uyeMail.ToString()).ToList();
            return View(messages);
        }
        public ActionResult NewMessage()
        {
            return View();
        }
    }
}