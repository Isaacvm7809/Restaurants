using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Migrations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

namespace Restaurants.Infrastructure.Persistence
{
    internal class RestaurantDbContext  : DbContext
    {
        internal DbSet<Restaurant> Restaurants { get; set; }
        internal DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=RestaurantsDb;Integrated Security=SSPI;Persist Security Info=True;");
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;TrustServerCertificate=True;Persist Security Info=False;Initial Catalog=RestaurantsDb;Data Source=localhost\SQLEXPRESS");
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);


        }


    }
}
