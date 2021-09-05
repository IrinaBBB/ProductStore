using ProductStore.Models.Entities;
using ProductStore.Models.ViewModels;
using System.Collections.Generic;

namespace ProductStore.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Save(ProductEditViewModel productViewModel);
        ProductEditViewModel GetProductEditViewModel();
    }
}
