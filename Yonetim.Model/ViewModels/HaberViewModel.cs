using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yonetim.Model.Entities;

namespace Yonetim.Model.ViewModels
{
    public class HaberViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Haber Başlığı 5-255 karakter arasında olmalıdır")]
        public string Baslik { get; set; }
        [Required]
        public string Icerik { get; set; }
        public DateTime EklenmeZamani { get; set; } = DateTime.Now;
        public int Hit { get; set; } = 0;
        public bool YayindaMi { get; set; } = false;
        public string Keywords { get; set; }
        public List<Kategori> Kategoriler { get; set; }
    }
}
