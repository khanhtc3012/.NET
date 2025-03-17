using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class ProductControllerTests
{
    private readonly string _connectionString = "Server=.;Database=TestDB;Trusted_Connection=True;";

    [Fact]
    public async Task Get_ReturnsProducts()
    {
        // Arrange
        var mockConnection = new Mock<SqlConnection>();
        mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Closed);
        mockConnection.Setup(conn => conn.Open());
        var mockCommand = new Mock<IDbCommand>();
        mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
        var mockReader = new Mock<IDataReader>();
        mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);
        mockReader.SetupSequence(reader => reader.Read())
                   .Returns(true)
                   .Returns(false);

        var productController = new ProductController();
        productController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        productController.DatabaseConnection = mockConnection.Object;

        // Act
        var result = await productController.Get();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<Product>>(result);
        mockConnection.Verify(conn => conn.Open(), Times.Once);
        mockCommand.Verify(cmd => cmd.ExecuteReader(), Times.Once);
    }

    [Fact]
    public async Task Get_EmptyResult()
    {
        // Arrange
        var mockConnection = new Mock<SqlConnection>();
        mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Closed);
        mockConnection.Setup(conn => conn.Open());
        var mockCommand = new Mock<IDbCommand>();
        mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
        var mockReader = new Mock<IDataReader>();
        mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(mockReader.Object);
        mockReader.SetupSequence(reader => reader.Read())
                   .Returns(false);

        var productController = new ProductController();
        productController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        productController.DatabaseConnection = mockConnection.Object;

        // Act
        var result = await productController.Get();

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
        mockConnection.Verify(conn => conn.Open(), Times.Once);
        mockCommand.Verify(cmd => cmd.ExecuteReader(), Times.Once);
    }

    [Fact]
    public async Task Get_ThrowsExceptionOnOpenFailure()
    {
        // Arrange
        var mockConnection = new Mock<SqlConnection>();
        mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Closed);
        mockConnection.Setup(conn => conn.Open()).Throws(new SqlException("Failed to open connection"));

        var productController = new ProductController();
        productController.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };
        productController.DatabaseConnection = mockConnection.Object;

        // Act & Assert
        await Assert.ThrowsAsync<SqlException>(() => productController.Get());
        mockConnection.Verify(conn => conn.Open(), Times.Once);
    }
}