using NUnit.Framework;
using System;

namespace WEB_API.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_WithNullSku_ShouldThrowArgumentException()
        {
            // Arrange
            var product = new Product();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.Sku = null);
        }

        [Test]
        public void Constructor_WithNegativePrice_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var product = new Product();

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.Price = -1);
        }

        [Test]
        public void Constructor_WithInvalidImageUrl_ShouldThrowArgumentNullException()
        {
            // Arrange
            var product = new Product();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => product.ImageUrl = null);
        }
    }
}