using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yonetim.Model.ViewModels
{
    public class KategoriViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
    }
}
