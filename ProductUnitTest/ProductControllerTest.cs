using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductStore.Controllers;
using ProductStore.Models.Entities;
using ProductStore.Models.Interfaces;
using ProductStore.Models.ViewModels;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ProductUnitTest
{
    [TestClass]
    public class ProductControllerTest
    {
        private Mock<IProductRepository> _repository;

        List<Product> fakeProducts; 
        List<Category> fakeCategories;

        [TestInitialize]
        public void SetupContext()
        {
            _repository = new Mock<IProductRepository>();
            var fakeProducts = new List<Product>
            {
                new() { Name = "Hammer", Price = 121.50m, CategoryId = 1},
                new() { Name = "Vinkelsliper", Price = 1520.00m, CategoryId = 1},
                new() { Name = "Melk", Price = 14.50m, CategoryId = 2},
                new() { Name = "Kjøttkaker", Price = 32.00m, CategoryId = 2},
                new() { Name = "Brød", Price = 25.50m, CategoryId = 2}
            };
            fakeCategories = new List<Category>
            {
                new() { Name = "Verktøy", CategoryId = 3 },                 
                new() { Name = "Dagligvarer", CategoryId = 2 }, 
                new() { Name = "Kjøretøy", CategoryId = 1 }

            };

            _repository.Setup(x => x.GetAll()).Returns(fakeProducts);
        }

        [TestMethod]
        public void CreateReturnsNotNullResult()
        {
            // Arrange 
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "View Result is null");
        }

        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange 
            var controller = new ProductController(_repository.Object);

            // Act 
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "View Result is null");
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
            // test på at save er kalt et bestemt antall ganger
            _repository.Verify(x => x.Save(It.IsAny<ProductEditViewModel>()), Times.Exactly(1));

        }

        [TestMethod]
        public void CreateRedirectActionRedirectsToIndexAction()
        {
            //Arrange
            var mockRepo = new Mock<IProductRepository>();            
            var controller = new ProductController(mockRepo.Object);            
            controller.ControllerContext = MockHelpers.FakeControllerContext(false);

            var tempData = new
                TempDataDictionary(
                    controller.ControllerContext.HttpContext, Mock.Of<ITempDataProvider>()); 
            controller.TempData = tempData; 
            var model = new ProductEditViewModel
            {
                Price = 100,
                Description = "Description of product"
            };

            //Act
            var result = controller.Create(model) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result, "RedirectToIndex needs to redirect to the Index action");            
            Assert.AreEqual("Index", result.ActionName as string);
        }

        [TestMethod]
        public void CreateReturnsViewIfModelIsInvalid()
        {
            //Arrange
            var mockRepo = new Mock<IProductRepository>();
            var controller = new ProductController(mockRepo.Object);
            controller.ControllerContext = MockHelpers.FakeControllerContext(false);
            var tempData = new
                TempDataDictionary(
                    controller.ControllerContext.HttpContext, Mock.Of<ITempDataProvider>());
            controller.TempData = tempData;
            var model = new ProductEditViewModel
            {
                Name = ""
            };
            controller.ModelState.AddModelError("x", "Test Error");

            //Act
            var result = controller.Create(model) as ViewResult;

            //Assert
            Assert.IsNotNull(result, "View Result is null");
        }
    }
}
