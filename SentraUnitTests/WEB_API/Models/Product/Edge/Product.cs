using Xunit;
using WEB_API.Models;

namespace WEB_API.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Id_ShouldNotBeNegative()
        {
            // Arrange
            var product = new Product { Id = -1 };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { });
        }

        [Fact]
        public void Product_Sku_ShouldNotBeEmpty()
        {
            // Arrange
            var product = new Product { Sku = "" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => { });
        }

        [Fact]
        public void Product_Price_ShouldNotBeNegative()
        {
            // Arrange
            var product = new Product { Price = -1.0f };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { });
        }
    }
}