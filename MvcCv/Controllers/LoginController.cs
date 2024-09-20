using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TBL_ADMIN model)
        {
            CVDBEntities entities = new CVDBEntities();
            var userInfo = entities.TBL_ADMIN.FirstOrDefault(s => s.KullaniciAdi == model.KullaniciAdi && s.Sifre == model.Sifre);
            if(userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.KullaniciAdi,false);
                Session["KullaniciAdi"] = userInfo.KullaniciAdi.ToString();
                return RedirectToAction("Index","Egitim");
            }
           else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}