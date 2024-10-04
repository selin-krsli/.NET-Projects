using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult EnterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnterLogin(TBL_UYELER parametre)
        {
            var LoginInfo = dbKutuphane.TBL_UYELER.FirstOrDefault(s=>s.Mail==parametre.Mail && s.Sifre==parametre.Sifre);
            if(LoginInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(LoginInfo.Mail, false);
                Session["Mail"]=LoginInfo.Mail.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}