using Xunit;
using WEB_API.Models;

namespace WEB_API.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_ShouldBeInitializedWithDefaultValues()
        {
            // Arrange
            var product = new Product();

            // Act & Assert
            Assert.Equal(0, product.Id);
            Assert.Null(product.Sku);
            Assert.Null(product.Content);
            Assert.Equal(0f, product.Price);
            Assert.Null(product.DiscountPrice);
            Assert.False(product.IsActive);
            Assert.Null(product.ImageUrl);
            Assert.Equal(0, product.ViewCount);
            Assert.Equal(default(DateTime), product.CreatedAt);
        }

        [Fact]
        public void Product_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Sku = "SKU123",
                Content = "Sample content",
                Price = 99.99f,
                DiscountPrice = 89.99f,
                IsActive = true,
                ImageUrl = "http://example.com/image.jpg",
                ViewCount = 10,
                CreatedAt = DateTime.Now
            };

            // Act & Assert
            Assert.Equal(1, product.Id);
            Assert.Equal("SKU123", product.Sku);
            Assert.Equal("Sample content", product.Content);
            Assert.Equal(99.99f, product.Price);
            Assert.Equal(89.99f, product.DiscountPrice);
            Assert.True(product.IsActive);
            Assert.Equal("http://example.com/image.jpg", product.ImageUrl);
            Assert.Equal(10, product.ViewCount);
            Assert.Equal(DateTime.Now.Date, product.CreatedAt.Date); // Comparing date part only
        }
    }
}