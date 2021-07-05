using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System;

namespace ShopBridge.Repository
{
    public class AppDbContext : DbContext   
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "OnePlus CE 5G",
                Description = "OnePlus CE 5G Mobile",
                Price = 27999.00M
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Moto G 5G",
                Description = "Moto G 5G Mobile",
                Price = 21999.00M
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Samsung M42 5G",
                Description = "Samsung M42 5G Mobile",
                Price = 22999.00M
            });

        }
    }
}
