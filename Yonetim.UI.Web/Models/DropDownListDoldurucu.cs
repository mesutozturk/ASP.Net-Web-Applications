using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yonetim.BLL.Repository;

namespace Yonetim.UI.Web.Models
{
    public class DropDownListDoldurucu
    {
        public static List<SelectListItem> KategoriList()
        {
            return new KategoriRepo().GetAll()
                .OrderBy(x => x.Ad).
                Select(item => new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Ad
                }).ToList();
        }
    }
}