using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class ProductControllerTests
{
    [Fact]
    public async Task Get_ReturnsEmptyList_WhenDatabaseConnectionFails()
    {
        // Arrange
        var mockConnectionStringProvider = new Mock<IConnectionStringProvider>();
        mockConnectionStringProvider.Setup(provider => provider.GetConnectionString()).Returns("InvalidConnectionString");

        var controller = new ProductController(mockConnectionStringProvider.Object);

        // Act
        var result = await controller.Get();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task Get_ThrowsException_WhenQueryExecutionFails()
    {
        // Arrange
        var mockConnectionStringProvider = new Mock<IConnectionStringProvider>();
        mockConnectionStringProvider.Setup(provider => provider.GetConnectionString()).Returns("ValidConnectionString");

        var mockSqlConnection = new Mock<SqlConnection>(mockConnectionStringProvider.Object.GetConnectionString());
        mockSqlConnection.Setup(conn => conn.Open()).Throws(new SqlException());

        var controller = new ProductController(mockConnectionStringProvider.Object)
        {
            ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
            }
        };

        // Act & Assert
        await Assert.ThrowsAsync<SqlException>(() => controller.Get());
    }

    [Fact]
    public async Task Get_ThrowsArgumentNullException_WhenCommandTextIsNull()
    {
        // Arrange
        var mockConnectionStringProvider = new Mock<IConnectionStringProvider>();
        mockConnectionStringProvider.Setup(provider => provider.GetConnectionString()).Returns("ValidConnectionString");

        var controller = new ProductController(mockConnectionStringProvider.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => controller.Get());
    }
}