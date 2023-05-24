using BooksApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksApp.Data.Concrete.EfCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Stock).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.Property(x => x.PageCount).IsRequired();

            builder.Property(x => x.EditionYear).IsRequired();

            builder.Property(x => x.EditionNumber).IsRequired();

            builder.HasData(
                new Book { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Fahrenheit 451", Stock = 10, Price = 75, PageCount = 150, EditionYear = 2020, EditionNumber = 1, Url="fahrenheit-451" },
                new Book { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Kadınlar Ülkesi", Stock = 10, Price = 175, PageCount = 120, EditionYear = 2010, EditionNumber = 43, Url="kadinlar-ulkesi" },
                new Book { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "İnsanlar", Stock = 10, Price = 705, PageCount = 180, EditionYear = 2010, EditionNumber = 13, Url="insanlar" },
                new Book { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Görünmez Adam", Stock = 10, Price = 15, PageCount = 190, EditionYear = 2022, EditionNumber = 2, Url="gorunmez-adam" },
                new Book { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Siyah Günce", Stock = 10, Price = 47, PageCount = 250, EditionYear = 2018, EditionNumber = 13, Url="siyah-gunce" },
                new Book { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Nebo'nun Mavi Kitabı", Stock = 10, Price = 68, PageCount = 50, EditionYear = 2016, EditionNumber = 8, Url="nebonun-mavi-kitabi" },
                new Book { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Evrenin Sonundaki Restoran", Stock = 0, Price = 114, PageCount = 15, EditionYear = 2021, EditionNumber = 7, Url="evrenin-sonundaki-restoran" },
                new Book { Id = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Beni Kim Öldürdü?", Stock = 10, Price = 247, PageCount = 330, EditionYear = 2020, EditionNumber = 4, Url="beni-kim-oldurdu" },
                new Book { Id = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Zihin Kütüphanesi", Stock = 0, Price = 300, PageCount = 240, EditionYear = 2022, EditionNumber = 1, Url="zihin-kutuphanesi" },
                new Book { Id = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Yeni Bir Yaşam", Stock = 10, Price = 166, PageCount = 400, EditionYear = 2019, EditionNumber = 11, Url="yeni-bir-yasam" },
                new Book { Id = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Gecenin Kraliçesi", Stock = 10, Price = 19, PageCount = 97, EditionYear = 2020, EditionNumber = 12, Url="gecenin-kralicesi" },
                new Book { Id = 12, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Efendi Uyanıyor", Stock = 10, Price = 75, PageCount = 125, EditionYear = 2020, EditionNumber = 10, Url="efendi-uyaniyor" }
            );
        }
    }
}