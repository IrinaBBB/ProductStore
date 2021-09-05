using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductStore.Controllers;
using ProductStore.Models.Entities;
using ProductStore.Models.Interfaces;
using ProductStore.Models.ViewModels;
using System.Collections;
using System.Collections.Generic;

namespace ProductUnitTest
{
    [TestClass]
    public class ProductControllerTest
    {
        Mock<IProductRepository> _repository;

        [TestInitialize]
        public void Setup()
        {
            _repository = new Mock<IProductRepository>();
            List<Product> fakeproducts = new List<Product>
            {
                new Product{ Name = "Hammer", Price = 121.50m, CategoryId = 1},
                new Product{ Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 1},
                new Product{ Name = "Melk", Price = 14.50m, CategoryId = 2},
                new Product{ Name = "Kjøttkaker", Price = 32.00m, CategoryId = 2},
                new Product{ Name = "Brød", Price = 25.50m, CategoryId = 2}
            };
            _repository.Setup(x => x.GetAll()).Returns(fakeproducts);
        }

        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange 
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "View Result i null");
        }

        [TestMethod]
        public void IndexReturnsAllProducts()
        {
            // Arrange 
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = controller.Index() as ViewResult;

            // Assert 
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Product));
            Assert.IsNotNull(result, "View Result is null");
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number products");
        }

        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        {
            // Arrange 
            _repository = new Mock<IProductRepository>();
            _repository.Setup(x => x.Save(It.IsAny<ProductEditViewModel>()));
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = controller.Create(new ProductEditViewModel());

            // Assert 
            _repository.VerifyAll();
            // test på at save er kalt et betemt antall ganger
            _repository.Verify(x => x.Save(It.IsAny<ProductEditViewModel>()), Times.Exactly(1));

        }
    }
}
