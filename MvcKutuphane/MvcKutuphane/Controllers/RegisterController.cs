using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class RegisterController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult EnterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnterRegister(TBL_UYELER parametre)
        {
            if(!ModelState.IsValid)
            {
                return View("EnterRegister");
            }
            dbKutuphane.TBL_UYELER.Add(parametre);
            dbKutuphane.SaveChanges();
            return View();
        }
    }
}