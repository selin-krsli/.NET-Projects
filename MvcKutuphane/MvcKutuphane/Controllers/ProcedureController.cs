using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class ProcedureController : Controller
    {
        DBKUTUPHANEEntities dbKutuphane = new DBKUTUPHANEEntities(); 
        public ActionResult Index()
        {
            var values = dbKutuphane.TBL_HAREKET.Where(s=>s.IslemDurum==true).ToList();
            return View(values);
        }
    }
}