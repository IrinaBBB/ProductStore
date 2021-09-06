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
            var products = _repository.GetAll();

            return View(products);
        }

        public ActionResult Create()
        {
            var product = _repository.GetProductEditViewModel();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductEditViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            try
            {
                _repository.Save(productViewModel);
                TempData["message"] = $"{productViewModel.Name} har blitt opprettet";
                return RedirectToAction("Index");
            }
            catch
            {
                return View(productViewModel);
            }
        }
    }
}
