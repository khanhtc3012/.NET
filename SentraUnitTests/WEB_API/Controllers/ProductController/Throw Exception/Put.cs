using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Data.SqlClient;
using WEB_API.Controllers;
using WEB_API.Models;
using Xunit;

namespace WEB_API.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<SqlConnection> _mockConnection;
        private readonly Mock<IDapper> _mockDapper;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockConnection = new Mock<SqlConnection>();
            _mockDapper = new Mock<IDapper>();
            _controller = new ProductController(_mockConnection.Object, _mockDapper.Object);
        }

        [Fact]
        public async Task Put_WithClosedConnection_ThrowsSqlException()
        {
            // Arrange
            var id = 1;
            var product = new Product { Sku = "SKU123", Content = "Content", Price = 100, IsActive = true, ImageUrl = "image.jpg" };
            _mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Closed);

            // Act & Assert
            await Assert.ThrowsAsync<SqlException>(() => _controller.Put(id, product));
        }

        [Fact]
        public async Task Put_WithInvalidConnectionString_ThrowsSqlException()
        {
            // Arrange
            var id = 1;
            var product = new Product { Sku = "SKU123", Content = "Content", Price = 100, IsActive = true, ImageUrl = "image.jpg" };
            _controller = new ProductController(null, _mockDapper.Object);

            // Act & Assert
            await Assert.ThrowsAsync<SqlException>(() => _controller.Put(id, product));
        }

        [Fact]
        public async Task Put_WithNullProduct_ThrowsArgumentNullException()
        {
            // Arrange
            var id = 1;
            _controller = new ProductController(_mockConnection.Object, _mockDapper.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _controller.Put(id, null));
        }
    }
}