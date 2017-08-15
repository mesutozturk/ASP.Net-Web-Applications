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
            var model = new HaberRepo().GetAll().Select(x => new HaberViewModel()
            {
                Id = x.Id,
                Kategoriler = x.Kategoriler.Select(y => y.Id).ToList(),
                Baslik = x.Baslik,
                Keywords = x.Keywords,
                Icerik = x.Icerik,
                YayindaMi = x.YayindaMi,
                EklenmeZamani = x.EklenmeZamani,
                Hit = x.Hit
            }).ToList();
            return View(model);
        }

        public ActionResult Ekle()
        {
            ViewBag.Kategoriler = DropDownListDoldurucu.KategoriList();
            return View();
        }
        [HttpPost, ValidateInput(false)]
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
            catch (DbEntityValidationException ex)
            {
                return View(model);
            }
        }

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var haber = new HaberRepo().GetByID(id.Value);
            if (haber == null)
                return RedirectToAction("Index");
            var kategoriList = DropDownListDoldurucu.KategoriList();
            foreach (var item in kategoriList)
            {
                if (haber.Kategoriler.Select(x => x.Id).Contains(int.Parse(item.Value)))
                    item.Selected = true;
            }
            ViewBag.Kategoriler = kategoriList.OrderByDescending(x=>x.Selected);

            var model = new HaberViewModel()
            {
                Icerik = haber.Icerik,
                Id = haber.Id,
                Kategoriler = haber.Kategoriler.Select(x => x.Id).ToList(),
                Baslik = haber.Baslik,
                Keywords = haber.Keywords,
                YayindaMi = haber.YayindaMi,
                EklenmeZamani = haber.EklenmeZamani
            };

            return View(model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Duzenle(HaberViewModel model)
        {
            ViewBag.Kategoriler = DropDownListDoldurucu.KategoriList();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Haber düzenlenirken bir hata oluştu");
                return View(model);
            }
            try
            {
                new HaberRepo().Update(model);
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
        }

    }
}