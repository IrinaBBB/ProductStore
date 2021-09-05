using Microsoft.AspNetCore.Mvc;
using ProductStore.Models.Entities;
using ProductStore.Models.Interfaces;
using ProductStore.Models.ViewModels;
using System.Collections.Generic;

namespace ProductStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            IEnumerable<Product> products = _repository.GetAll();

            return View(products);
        }

        public ActionResult Create()
        {
            var product = _repository.GetProductEditViewModel();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(ProductEditViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _repository.Save(productViewModel);
                    TempData["message"] = string.Format("{0} har blitt opprettet", productViewModel.Name);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(productViewModel);
                }
            }
            return View(productViewModel);
        }
    }
}
