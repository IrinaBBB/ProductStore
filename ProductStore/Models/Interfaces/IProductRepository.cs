using ProductStore.Models.Entities;
using System.Collections.Generic;

namespace ProductStore.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
