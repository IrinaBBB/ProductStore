using Microsoft.AspNetCore.Mvc;
using ProductStore.Models.Entities;
using ProductStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                _repository.Save(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
