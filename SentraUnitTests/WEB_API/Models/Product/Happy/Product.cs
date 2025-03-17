using Xunit;
using WEB_API.Models;

namespace WEB_API.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_InitializesProductWithDefaultValues()
        {
            // Arrange & Act
            var product = new Product();

            // Assert
            Assert.Equal(0, product.Id);
            Assert.Null(product.Sku);
            Assert.Null(product.Content);
            Assert.Equal(0.0f, product.Price);
            Assert.Null(product.DiscountPrice);
            Assert.False(product.IsActive);
            Assert.Null(product.ImageUrl);
            Assert.Equal(0, product.ViewCount);
            Assert.Equal(default(DateTime), product.CreatedAt);
        }

        [Fact]
        public void Properties_SetCorrectly()
        {
            // Arrange
            var sku = "SKU123";
            var content = "Sample content";
            var price = 19.99f;
            var discountPrice = 15.99f;
            var isActive = true;
            var imageUrl = "http://example.com/image.jpg";
            var viewCount = 10;
            var createdAt = DateTime.Now;

            // Act
            var product = new Product
            {
                Sku = sku,
                Content = content,
                Price = price,
                DiscountPrice = discountPrice,
                IsActive = isActive,
                ImageUrl = imageUrl,
                ViewCount = viewCount,
                CreatedAt = createdAt
            };

            // Assert
            Assert.Equal(sku, product.Sku);
            Assert.Equal(content, product.Content);
            Assert.Equal(price, product.Price);
            Assert.Equal(discountPrice, product.DiscountPrice);
            Assert.Equal(isActive, product.IsActive);
            Assert.Equal(imageUrl, product.ImageUrl);
            Assert.Equal(viewCount, product.ViewCount);
            Assert.Equal(createdAt, product.CreatedAt);
        }
    }
}