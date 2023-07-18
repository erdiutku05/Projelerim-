using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomaston.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }

        public short Stok { get; set; }

        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }

        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]

        public string UrunGorsel { get; set; }

        //public int KategoriId { get; set; }

        public virtual Kategori Kategori { get; set; } // her ürünün sadece bir kategorisi olabilir o yüzden tek bir kategori tanımlananacak şekilde yazdık. virtual sayesinde bağlantılı olduğu tabloları da bastırırken kategoriyi kullanabileceğiz rahatça.

        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}