using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using North.Models;

namespace North.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Urunler(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            var kategori = new NorthwindEntities().Categories.Find(id);
            if (kategori != null)
            {
                var urunler = kategori.Products.ToList();
                return View(urunler);
            }
            return View(new List<Product>());
        }
    }
}