using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using North.Models;
using North.Models.ViewModels;

namespace North.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            var db = new NorthwindEntities();
            var urun = db.Products.Find(id.Value);
            if (urun == null)
                return RedirectToAction("Index", "Home");
            ViewBag.Title = $"{urun.ProductName} - Ürün Düzenleme";
            var kategoriler = new List<SelectListItem>();
            db.Categories.ToList().ForEach(x =>
                kategoriler.Add(new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                })
            );
            ViewBag.Kategoriler = kategoriler;
            return View(urun);
        }

        [HttpPost]
        public ActionResult Duzenle(Product model)
        {
            var db = new NorthwindEntities();
            var kategoriler = new List<SelectListItem>();
            db.Categories.ToList().ForEach(x =>
                kategoriler.Add(new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                })
            );
            ViewBag.Kategoriler = kategoriler;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Güncelleme işlemi başarısız");
                return View(model);
            }
            var urun = db.Products.Find(model.ProductID);
            if (urun == null)
                return RedirectToAction("Index", "Home");

            try
            {
                urun.ProductName = model.ProductName;
                urun.UnitPrice = model.UnitPrice;
                urun.UnitsInStock = model.UnitsInStock;
                urun.Discontinued = model.Discontinued;
                urun.CategoryID = model.CategoryID;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Güncelleme işlemi başarısız. " + e.Message);
                return View(model);
            }
            //return View(model);
            return RedirectToAction("Duzenle", new { id = urun.ProductID });
        }
        [HttpGet]
        public ActionResult Yeni()
        {
            var db = new NorthwindEntities();
            var kategoriler = new List<SelectListItem>();
            db.Categories.ToList().ForEach(x =>
                kategoriler.Add(new SelectListItem()
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                })
            );
            ViewBag.Kategoriler = kategoriler;
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Product model)
        {
            var urun = new Product()
            {
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                Discontinued = model.Discontinued,
                CategoryID = model.CategoryID,
                UnitsInStock = model.UnitsInStock
            };
            try
            {
                var db = new NorthwindEntities();
                db.Products.Add(urun);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("Duzenle", new { id = urun.ProductID });
        }

        public ActionResult Ara()
        {
            return View();
        }

        public JsonResult Bul(string key)
        {
            var db = new NorthwindEntities();
            var sonuc = db.Products.Where(x => x.ProductName.ToLower().Contains(key.ToLower()) ||
                                               x.Category.CategoryName.ToLower().Contains(key.ToLower())).Select(x => new ProductViewModel()
                                               {
                                                   ProductName = x.ProductName,
                                                   UnitPrice = x.UnitPrice,
                                                   Discontinued = x.Discontinued,
                                                   CategoryName = x.Category.CategoryName,
                                                   UnitsInStock = x.UnitsInStock,
                                                   ProductID = x.ProductID,
                                                   CategoryID = x.CategoryID
                                               }).ToList();

            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }
    }
}