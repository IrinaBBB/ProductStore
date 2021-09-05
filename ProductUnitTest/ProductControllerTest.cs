using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductStore.Controllers;
using ProductStore.Models.Entities;
using System.Collections;
using System.Collections.Generic;

namespace ProductUnitTest
{
    [TestClass]
    public class ProductControllerTest
    {
        IProductRepository _repository;

        [TestMethod]
        public void IndexReturnsNotNullResult()
        {
            // Arrange
            var controller = new ProductController();

            // Act 
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "View Result i null");
        }

        [TestMethod]
        public void IndexReturnsAllProducts()
        {
            // Arrange 
            _repository = new FakeProductRepository();
            var controller = new ProductController(_repository);

            // Act 
            var result = controller.Index() as ViewResult;

            // Assert 
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Product));
            Assert.IsNotNull(result, "View Result is null");
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number products");
        }
    }
}
