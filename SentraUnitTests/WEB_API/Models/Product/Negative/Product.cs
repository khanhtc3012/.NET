using Xunit;
using WEB_API.Models;

namespace WEB_API.Tests
{
    public class ProductNegativeTests
    {
        [Fact]
        public void TestProductWithNullSku()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Sku = null,
                Content = "Sample content",
                Price = 19.99f,
                IsActive = true,
                ImageUrl = "http://example.com/image.jpg",
                ViewCount = 0,
                CreatedAt = DateTime.Now
            };

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => product.Sku);
        }

        [Fact]
        public void TestProductWithEmptyContent()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Sku = "SKU123",
                Content = "",
                Price = 19.99f,
                IsActive = true,
                ImageUrl = "http://example.com/image.jpg",
                ViewCount = 0,
                CreatedAt = DateTime.Now
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.Content);
        }

        [Fact]
        public void TestProductWithNegativePrice()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Sku = "SKU123",
                Content = "Sample content",
                Price = -19.99f,
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