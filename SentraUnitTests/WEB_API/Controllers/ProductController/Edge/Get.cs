using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

[TestFixture]
public class ProductControllerTests
{
    private Mock<SqlConnection> _mockConnection;
    private ProductController _controller;
    private string _connectionString = "TestConnectionString";

    [SetUp]
    public void Setup()
    {
        _mockConnection = new Mock<SqlConnection>(_connectionString);
        _controller = new ProductController();
        _controller._connectionString = _connectionString;
    }

    [Test]
    public async Task Get_ReturnsProducts_WhenConnectionIsOpen()
    {
        // Arrange
        _mockConnection.Setup(conn => conn.State).Returns(ConnectionState.Open);
        _mockConnection.Setup(conn => conn.QueryAsync<Product>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<int?>(), It.IsAny<CommandType>()))
                        .ReturnsAsync(new List<Product>());

        // Act
        var result = await _controller.Get();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result);
    }

    [Test]
    public async Task Get_OpensConnection_WhenItIsClosed()
    {
        // Arrange
        _mockConnection.Setup(conn => conn.State).Returns(ConnectionState.Closed);
        _mockConnection.Setup(conn => conn.Open());
        _mockConnection.Setup(conn => conn.QueryAsync<Product>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<int?>(), It.IsAny<CommandType>()))
                        .ReturnsAsync(new List<Product>());

        // Act
        await _controller.Get();

        // Assert
        _mockConnection.Verify(conn => conn.Open(), Times.Once);
    }

    [Test]
    public async Task Get_ReturnsEmptyList_WhenNoProductsFound()
    {
        // Arrange
        _mockConnection.Setup(conn => conn.State).Returns(ConnectionState.Open);
        _mockConnection.Setup(conn => conn.QueryAsync<Product>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<IDbTransaction>(), It.IsAny<int?>(), It.IsAny<CommandType>()))
                        .ReturnsAsync((IEnumerable<Product>)null);

        // Act
        var result = await _controller.Get();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }
}