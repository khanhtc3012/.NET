using NUnit.Framework;
using WEB_API.Controllers;
using WEB_API.Models;
using Moq;

[TestFixture]
public class ProductControllerTests
{
    [Test]
    public async Task Get_ReturnsEmptyList_WhenNoData()
    {
        // Arrange
        string connectionString = "Server=.;Database=TestDB;Trusted_Connection=True;";
        var mockConnection = new Mock<SqlConnection>();
        mockConnection.Setup(m => m.State).Returns(System.Data.ConnectionState.Closed);
        mockConnection.Setup(m => m.Open());
        mockConnection.Setup(m => m.QueryAsync<Product>(It.IsAny<string>(), It.IsAny<object?>(), It.IsAny<IDbTransaction?>(), It.IsAny<int?>(), It.IsAny<System.Data.CommandType>()))
                      .ReturnsAsync(new List<Product>());

        var productController = new ProductController(mockConnection.Object);

        // Act
        var result = await productController.Get();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [Test]
    public async Task Get_ThrowsException_WhenConnectionStringIsNull()
    {
        // Arrange
        string connectionString = null;
        var mockConnection = new Mock<SqlConnection>();

        var productController = new ProductController(mockConnection.Object);

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => productController.Get());
    }

    [Test]
    public async Task Get_ThrowsException_WhenQueryFails()
    {
        // Arrange
        string connectionString = "Server=.;Database=TestDB;Trusted_Connection=True;";
        var mockConnection = new Mock<SqlConnection>();
        mockConnection.Setup(m => m.State).Returns(System.Data.ConnectionState.Closed);
        mockConnection.Setup(m => m.Open());
        mockConnection.Setup(m => m.QueryAsync<Product>(It.IsAny<string>(), It.IsAny<object?>(), It.IsAny<IDbTransaction?>(), It.IsAny<int?>(), It.IsAny<System.Data.CommandType>()))
                      .ThrowsAsync(new SqlException());

        var productController = new ProductController(mockConnection.Object);

        // Act & Assert
        Assert.ThrowsAsync<SqlException>(() => productController.Get());
    }
}