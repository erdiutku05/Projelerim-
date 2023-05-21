using DataLayer.Concrete.EfCore.Extensions;
using DataLayer.Concrete.EfCore.Config;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Concrete.EfCore.Context
{
    public class AkademiContext : IdentityDbContext<User, Role, string>
    {
        public AkademiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<TeacherBranch> TeacherBranches { get; set; }

        public DbSet<TeacherStudent> TeacherStudents { get; set; }

        public DbSet<Advert> Adverts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BranchConfig).Assembly);
            base.OnModelCreating(modelBuilder);

        }



    }


}
