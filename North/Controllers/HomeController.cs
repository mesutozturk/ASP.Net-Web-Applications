using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using North.Models;

namespace North.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var kategoriler = new NorthwindEntities().Categories.ToList();
            return View(kategoriler);
        }

        public PartialViewResult MenuPartial()
        {
            var model = new NorthwindEntities().Categories.ToList();
            return PartialView("_PartialMenu", model);
        }
    }
}