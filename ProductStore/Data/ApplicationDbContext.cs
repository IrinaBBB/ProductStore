using Microsoft.EntityFrameworkCore;
using ProductStore.Models.Entities;

namespace ProductStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, Name = "Verktøy" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, Name = "Dagligvarer" });


            modelBuilder.Entity<Manufacturer>()
                .HasData(new Manufacturer { ManufacturerId = 1, Name = "Bilthema", Address = "Teglverkveien 15, 8006 Bodø" });
            modelBuilder.Entity<Manufacturer>()
                .HasData(new Manufacturer { ManufacturerId = 2, Name = "Orkla Foods Norge AS", Address = "Drammensveien 149A 0277 Oslo" });


            modelBuilder.Entity<Product>()
                .HasData(new Product { ProductId = 1, Name = "Hammer", Price = 121.50m, CategoryId = 1, ManufacturerId = 1 });
            modelBuilder.Entity<Product>()
                .HasData(new Product { ProductId = 2, Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 1, ManufacturerId = 1 });
            modelBuilder.Entity<Product>()
                .HasData(new Product { ProductId = 3, Name = "Melk", Price = 14.50m, CategoryId = 2, ManufacturerId = 2 });
            modelBuilder.Entity<Product>()
                .HasData(new Product { ProductId = 4, Name = "Kjøttkaker", Price = 32.00m, CategoryId = 2, ManufacturerId = 2 });
            modelBuilder.Entity<Product>()
                .HasData(new Product{ ProductId = 5, Name = "Brød", Price = 25.50m, CategoryId = 2, ManufacturerId = 2 });
        }
    }
}
