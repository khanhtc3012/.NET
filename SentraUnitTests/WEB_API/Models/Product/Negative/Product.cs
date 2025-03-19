using Xunit;
using System;

namespace WEB_API.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_WithNullSku_ThrowsArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Product { Sku = null });
        }

        [Fact]
        public void Constructor_WithNegativePrice_ThrowsArgumentOutOfRangeException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product { Price = -10f });
        }

        [Fact]
        public void Constructor_WithInvalidImageUrl_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Product { ImageUrl = "invalid_url" });
        }
    }
}