using Microsoft.EntityFrameworkCore;
using ProductStore.Data;
using ProductStore.Models.Entities;
using ProductStore.Models.Interfaces;
using ProductStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProductStore.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products =
                _db.Products
                    .Include(p => p.Category)
                    .Include(p => p.Manufacturer)
                    .ToList();
                   
            return products;
        }

        public ProductEditViewModel GetProductEditViewModel()
        {
            var categories = _db.Categories;
            var manufacturers = _db.Manufacturers;

            var productEditViewModel = new ProductEditViewModel{
                Categories = categories.ToList(),
                Manufacturers = manufacturers.ToList()
            };

            return productEditViewModel;
        }

        public void Save(ProductEditViewModel productViewModel)
        {
            var product = new Product
            {
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                Price = productViewModel.Price,
                ManufacturerId = productViewModel.ManufacturerId,
                CategoryId = productViewModel.CategoryId
            };

            _db.Add(product);
            _db.SaveChanges();
        }
    }
}
