using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Yonetim.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        #region PartialResults

        public PartialViewResult NavHeaderPartial()
        {
            return PartialView("_NavHeaderPartial");
        }

        public PartialViewResult NavRightPartial()
        {
            return PartialView("_NavbarRightPartial");
        }

        public PartialViewResult SideBarPartial()
        {
            return PartialView("_SideBarPartial");
        }
        
        #endregion    
    }
}