using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        GenericRepository<TBL_CONTACT> repository = new GenericRepository<TBL_CONTACT>();
        public ActionResult Index()
        {
            var values = repository.List();
            return View(values);
        }
    }
}