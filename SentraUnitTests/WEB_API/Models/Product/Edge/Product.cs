using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WEB_API.Tests.Models
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestProductConstructorWithMinimumValues()
        {
            // Arrange
            var product = new Product
            {
                Id = 0,
                Sku = "SKU1",
                Content = "Content1",
                Price = 0.0f,
                DiscountPrice = null,
                IsActive = false,
                ImageUrl = "",
                ViewCount = 0,
                CreatedAt = DateTime.MinValue
            };

            // Act & Assert
            Assert.AreEqual(0, product.Id);
            Assert.AreEqual("SKU1", product.Sku);
            Assert.AreEqual("Content1", product.Content);
            Assert.AreEqual(0.0f, product.Price);
            Assert.IsNull(product.DiscountPrice);
            Assert.IsFalse(product.IsActive);
            Assert.AreEqual("", product.ImageUrl);
            Assert.AreEqual(0, product.ViewCount);
            Assert.AreEqual(DateTime.MinValue, product.CreatedAt);
        }

        [TestMethod]
        public void TestProductConstructorWithMaximumValues()
        {
            // Arrange
            var product = new Product
            {
                Id = int.MaxValue,
                Sku = new string('A', 255),
                Content = new string('B', 255),
                Price = float.MaxValue,
                DiscountPrice = float.MaxValue,
                IsActive = true,
                ImageUrl = new string('C', 255),
                ViewCount = int.MaxValue,
                CreatedAt = DateTime.MaxValue
            };

            // Act & Assert
            Assert.AreEqual(int.MaxValue, product.Id);
            Assert.AreEqual(new string('A', 255), product.Sku);
            Assert.AreEqual(new string('B', 255), product.Content);
            Assert.AreEqual(float.MaxValue, product.Price);
            Assert.AreEqual(float.MaxValue, product.DiscountPrice);
            Assert.IsTrue(product.IsActive);
            Assert.AreEqual(new string('C', 255), product.ImageUrl);
            Assert.AreEqual(int.MaxValue, product.ViewCount);
            Assert.AreEqual(DateTime.MaxValue, product.CreatedAt);
        }
    }
}