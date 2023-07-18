using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomaston.Models.Siniflar
{
    public class Kategori   //kategori tablomuzun sınıfını oluşturduk. burada kategori tablomuzun proplarını yani elemanlarını girip kategori tablomuzu oluşturacağız.
    {
        [Key] // Id'yi primary key olarak verir.karışmamasını sağlar ve belli bir düzende otomatik verir.
        public int KategoriId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }

        public ICollection<Urun> Uruns { get; set; } // bir kategoride birden fazla ürün olabilir o yüzden bire çok ilişkisi yaptık.




    }
}