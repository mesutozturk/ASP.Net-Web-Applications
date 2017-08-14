using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yonetim.BLL.Repository;
using Yonetim.Model.Entities;
using Yonetim.Model.ViewModels;
using Yonetim.UI.Web.Models;

namespace Yonetim.UI.Web.Controllers
{
    public class HaberController : Controller
    {
        // GET: Haber
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ekle()
        {
            ViewBag.Kategoriler = DropDownListDoldurucu.KategoriList();
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(HaberViewModel model)
        {
            ViewBag.Kategoriler = DropDownListDoldurucu.KategoriList();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Haber eklerken bir hata meydana geldi");
                return View(model);
            }
            try
            {
                new HaberRepo().Insert(model);
                return RedirectToAction("Index");
            }
            catch(DbEntityValidationException ex)
            {
                return View(model);
            }
        }
    }
}