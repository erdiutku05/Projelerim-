using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OnlineTicariOtomaston.Models.Siniflar
{
    public class Context : DbContext


    {
        // context sınıfımıza tablolarımızın isimlerini giriyoruz.
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cariler> Carilers { get; set; }
        public DbSet<Departman> Departmans { get; set; }
        public DbSet<FaturaKalem> FaturaKalems { get; set; }
        public DbSet<Faturalar> Faturalars { get; set; }
        public DbSet<Gider> Giders { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<SatisHareket> SatisHarekets { get; set; }
        public DbSet<Urun> Uruns { get; set; }


    }
}