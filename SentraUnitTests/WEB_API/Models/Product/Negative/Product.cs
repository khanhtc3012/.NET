using Xunit;
using System;

namespace WEB_API.Tests.Models
{
    public class ProductTests
    {
        [Fact]
        public void Product_WithNullSku_ShouldThrowArgumentException()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Sku = null,
                Content = "Sample content",
                Price = 10.0f,
                IsActive = true,
                ImageUrl = "http://example.com/image.jpg",
                ViewCount = 0,
                CreatedAt = DateTime.Now
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.Sku);
        }

        [Fact]
        public void Product_WithEmptyContent_ShouldThrowArgumentException()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Sku = "SKU123",
                Content = "",
                Price = 10.0f,
                IsActive = true,
                ImageUrl = "http://example.com/image.jpg",
                ViewCount = 0,
                CreatedAt = DateTime.Now
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.Content);
        }

        [Fact]
        public void Product_WithNegativePrice_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Sku = "SKU123",
                Content = "Sample content",
                Price = -10.0f,
                IsActive = true,
                ImageUrl = "http://example.com/image.jpg",
                ViewCount = 0,
                CreatedAt = DateTime.Now
            };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.Price);
        }
    }
}