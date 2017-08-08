using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCGiris.Models;

namespace MVCGiris.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var urunler= Urun.Urunler;
            return View(urunler);
        }
        [HttpPost]
        public ActionResult Index(int a)
        {
            return View();
        }
    }
}