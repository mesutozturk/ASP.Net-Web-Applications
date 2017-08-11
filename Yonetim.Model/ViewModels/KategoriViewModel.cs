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
        [StringLength(50,ErrorMessage = "Kategori adı en fazla 50 karakter olabilir")]
        public string Ad { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }
}
