using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yonetim.BLL.Repository;
using Yonetim.Model.Entities;
using Yonetim.Model.ViewModels;

namespace Yonetim.UI.Web.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ekle()
        {
            return View();
        }

        public ActionResult Ekle(KategoriViewModel model)
        {
            try
            {
                new KategoriRepo().Insert(new Kategori()
                {
                    Ad = model.Ad,
                    Aciklama = model.Aciklama
                });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

        }
    }
}