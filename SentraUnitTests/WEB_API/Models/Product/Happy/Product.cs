using Xunit;
using WEB_API.Models;

namespace WEB_API.Tests
{
    public class ProductTests
    {
        [Fact]
        public void TestProductConstructor()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Sku = "SKU123",
                Content = "Sample content",
                Price = 19.99f,
                DiscountPrice = null,
                IsActive = true,
                ImageUrl = "http://example.com/image.jpg",
                ViewCount = 10,
                CreatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Equal(1, product.Id);
            Assert.Equal("SKU123", product.Sku);
            Assert.Equal("Sample content", product.Content);
            Assert.Equal(19.99f, product.Price);
            Assert.Null(product.DiscountPrice);
            Assert.True(product.IsActive);
            Assert.Equal("http://example.com/image.jpg", product.ImageUrl);
            Assert.Equal(10, product.ViewCount);
            Assert.NotNull(product.CreatedAt);
        }

        [Fact]
        public void TestProductWithDiscount()
        {
            // Arrange
            var product = new Product
            {
                Id = 2,
                Sku = "SKU456",
                Content = "Discounted content",
                Price = 29.99f,
                DiscountPrice = 14.99f,
                IsActive = true,
                ImageUrl = "http://example.com/discount-image.jpg",
                ViewCount = 20,
                CreatedAt = DateTime.UtcNow
            };

            // Act & Assert
            Assert.Equal(2, product.Id);
            Assert.Equal("SKU456", product.Sku);
            Assert.Equal("Discounted content", product.Content);
            Assert.Equal(29.99f, product.Price);
            Assert.Equal(14.99f, product.DiscountPrice);
            Assert.True(product.IsActive);
            Assert.Equal("http://example.com/discount-image.jpg", product.ImageUrl);
            Assert.Equal(20, product.ViewCount);
            Assert.NotNull(product.CreatedAt);
        }
    }
}