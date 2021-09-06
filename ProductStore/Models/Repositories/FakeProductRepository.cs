using ProductStore.Models.Entities;
using ProductStore.Models.Interfaces;
using ProductStore.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace ProductStore.Models.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>
            {
                new() { Name = "Hammer", Price = 121.50m, CategoryId = 1},
                new() { Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 1},
                new() { Name = "Melk", Price = 14.50m, CategoryId = 2},
                new() { Name = "Kjøttkaker", Price = 32.00m, CategoryId = 2},
                new() { Name = "Brød", Price = 25.50m, CategoryId = 2}
            };

            return products;
        }

        public ProductEditViewModel GetProductEditViewModel()
        {
            throw new NotImplementedException();
        }

        public void Save(ProductEditViewModel productViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
