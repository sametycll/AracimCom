using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-PI13KKV\\SQLEXPRESS;database=AracimComDb; integrated security=true;");

           
        } 

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Series> Seriess { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Vehicle> Vehicles{ get; set; }
        public DbSet<Notification> Notifications{ get; set; }



    }
}
