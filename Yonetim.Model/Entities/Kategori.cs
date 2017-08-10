using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yonetim.Model.Entities
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Ad { get; set; }
        public string Aciklama { get; set; }
        public virtual List<Haber> Haberler { get; set; } = new List<Haber>();
    }
}
