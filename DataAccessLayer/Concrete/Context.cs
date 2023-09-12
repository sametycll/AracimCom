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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message2>()
                .HasOne(x => x.SenderUser)
                .WithMany(y=>y.UserSender)
                .HasForeignKey(z=>z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message2>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.UserReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Series> Seriess { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Vehicle> Vehicles{ get; set; }
        public DbSet<Notification> Notifications{ get; set; }
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Manager> Managers{ get; set; }



    }
}
