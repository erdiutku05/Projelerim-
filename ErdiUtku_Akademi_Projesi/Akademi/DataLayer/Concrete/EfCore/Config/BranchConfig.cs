using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete.EfCore.Config
{
    public class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();
            builder.Property(x => x.BranchName).IsRequired();

            builder.HasData(
                new Branch
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Matematik",
                    Description = "Üniversite Düzeyinde Matematik Dersleri",
                    Url = "matematik"
                },

                new Branch
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Analiz",
                    Description = "Analiz 1-2-3-4 Dersleri",
                    Url = "analiz"
                },

                new Branch
                {
                    Id = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "İstatistik",
                    Description = "Üniversite Düzeyinde İstatistik Dersleri",
                    Url = "istatistik"
                },

                new Branch
                {
                    Id = 4,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Analitik Geometri",
                    Description = "Üniversite Düzeyinde Analitik Dersleri",
                    Url = "analitik-geometri"
                },

                new Branch
                {
                    Id = 5,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsApproved = true,
                    BranchName = "Oyun Teorisi",
                    Description = "Oyun Teorisi 1-2-3-4 Dersleri",
                    Url = "oyun-teorisi"
                },
                 new Branch
                 {
                     Id = 6,
                     CreatedDate = DateTime.Now,
                     UpdatedDate = DateTime.Now,
                     IsApproved = true,
                     BranchName = "Bilgisayar Programcılığı",
                     Description = "C# , Python , Java Dersleri",
                     Url = "bilgisayar-programciligi"
                 },
                  new Branch
                  {
                      Id = 7,
                      CreatedDate = DateTime.Now,
                      UpdatedDate = DateTime.Now,
                      IsApproved = true,
                      BranchName = "Algoritmalar",
                      Description = "Algoritmalar 1-2 dersleri verilir.",
                      Url = "algoritmalar"
                  },
                   new Branch
                   {
                       Id = 8,
                       CreatedDate = DateTime.Now,
                       UpdatedDate = DateTime.Now,
                       IsApproved = true,
                       BranchName = "Bilgisayar Mimarisi",
                       Description = "Bilgisayar Mimarisi 1-2 dersleri verilir.",
                       Url = "bilgisayar-mimarisi"
                   },
                    new Branch
                    {
                        Id = 9,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        IsApproved = true,
                        BranchName = "Soyut Matematik",
                        Description = "Soyut Matematik 1-2-3-4 dersleri verilir.",
                        Url = "soyut-matematik"
                    },
                     new Branch
                     {
                         Id = 10,
                         CreatedDate = DateTime.Now,
                         UpdatedDate = DateTime.Now,
                         IsApproved = true,
                         BranchName = "Matlab",
                         Description = "Matlab 1-2 dersleri verilir.",
                         Url = "matlab"
                     }


                );



        }
    }
}

