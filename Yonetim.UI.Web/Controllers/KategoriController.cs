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
            var model = new KategoriRepo().GetAll().Select(x => new KategoriViewModel()
            {
                Id = x.Id,
                Ad = x.Ad,
                Aciklama = x.Aciklama
            }).ToList();
            return View(model);
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
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

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var kategori = new KategoriRepo().GetByID(id.Value);
            if (kategori == null)
                return RedirectToAction("Index");
            var model = new KategoriViewModel()
            {
                Id = kategori.Id,
                Ad = kategori.Ad,
                Aciklama = kategori.Aciklama
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Duzenle(KategoriViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Kategori güncelleme işleminde hata oluştu");
                return View(model);
            }
            try
            {
                var kategori = new KategoriRepo().GetByID(model.Id);
                kategori.Ad = model.Ad;
                kategori.Aciklama = model.Aciklama;
                new KategoriRepo().Update();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }
    }
}