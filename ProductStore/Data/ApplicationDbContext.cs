using Microsoft.EntityFrameworkCore;
using ProductStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1, Name = "Hammer", Price = 121.50m, Category = "Verktøy" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 2, Name = "Vinkelsliper", Price = 1520.00m, Category = "Verktøy" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 3, Name = "Melk", Price = 14.50m, Category = "Dagligvarer" });
            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 4, Name = "Kjøttkaker", Price = 32.00m, Category = "Dagligvarer" });
            modelBuilder.Entity<Product>().HasData(new Product{ ProductId = 5, Name = "Brød", Price = 25.50m, Category = "Dagligvarer"});
        }
    }
}
