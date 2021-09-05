using ProductStore.Data;
using ProductStore.Models.Entities;
using ProductStore.Models.Interfaces;
using System.Collections.Generic;

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
            IEnumerable<Product> products = _db.Products;
            return products;
        }

        public void Save(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
