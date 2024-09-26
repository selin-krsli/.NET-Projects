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
        public ActionResult Index(int page = 1)
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
    }
}