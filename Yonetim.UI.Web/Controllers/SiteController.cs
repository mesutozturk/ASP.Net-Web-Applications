using System.Linq;
using System.Web.Mvc;
using Yonetim.BLL.Repository;
using Yonetim.Model.ViewModels;

namespace Yonetim.UI.Web.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            var model=new HaberRepo().GetAll().Where(x=>x.YayindaMi).Select(x=> new HaberViewModel()
            {
                Id = x.Id,
                Baslik = x.Baslik,
                EklenmeZamani = x.EklenmeZamani,
                Hit = x.Hit,
                Icerik = x.Icerik,
                Keywords = x.Keywords
            }).ToList();
            return View(model);
        }

        public ActionResult Haber(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var haber=new HaberRepo().GetByID(id.Value);
            if(haber==null) return RedirectToAction("Index");

            return View(haber);
        }
    }
}