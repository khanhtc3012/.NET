using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class ProductControllerTests
{
    private readonly Mock<SqlConnection> _mockConnection;
    private readonly Mock<IDapper> _mockDapper;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mockConnection = new Mock<SqlConnection>();
        _mockDapper = new Mock<IDapper>();
        _controller = new ProductController();
        _controller.DatabaseContext = _mockConnection.Object;
        _controller.Dapper = _mockDapper.Object;
    }

    [Fact]
    public async Task Post_WithInvalidSku_ReturnsBadRequest()
    {
        // Arrange
        var product = new Product { Sku = "invalid_sku", Content = "test content", Price = 100, IsActive = true, ImageUrl = "test.jpg" };
        _mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Closed);
        _mockConnection.Setup(conn => conn.Open()).Verifiable();

        // Act
        var result = await _controller.Post(product);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task Post_WithNullContent_ReturnsBadRequest()
    {
        // Arrange
        var product = new Product { Sku = "valid_sku", Content = null, Price = 100, IsActive = true, ImageUrl = "test.jpg" };
        _mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Closed);
        _mockConnection.Setup(conn => conn.Open()).Verifiable();

        // Act
        var result = await _controller.Post(product);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }

    [Fact]
    public async Task Post_WithNegativePrice_ReturnsBadRequest()
    {
        // Arrange
        var product = new Product { Sku = "valid_sku", Content = "test content", Price = -100, IsActive = true, ImageUrl = "test.jpg" };
        _mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Closed);
        _mockConnection.Setup(conn => conn.Open()).Verifiable();

        // Act
        var result = await _controller.Post(product);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}