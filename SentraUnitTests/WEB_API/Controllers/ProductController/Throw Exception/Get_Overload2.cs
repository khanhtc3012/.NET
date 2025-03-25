using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WEB_API.Models;
using Dapper;
using Moq;
using Xunit;

public class ProductControllerTests
{
    [Fact]
    public async Task Get_ThrowsExceptionOnClosedConnection()
    {
        // Arrange
        var controller = new ProductController();
        var mockConnection = new Mock<SqlConnection>();
        mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Closed);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Get(1));
    }

    [Fact]
    public async Task Get_ThrowsExceptionOnEmptyResult()
    {
        // Arrange
        var controller = new ProductController();
        var mockConnection = new Mock<SqlConnection>();
        mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Open);
        var mockCommand = new Mock<SqlCommand>();
        mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
        mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(new SqlDataReader());
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Get(1));
    }

    [Fact]
    public async Task Get_ThrowsExceptionOnInvalidId()
    {
        // Arrange
        var controller = new ProductController();
        var mockConnection = new Mock<SqlConnection>();
        mockConnection.Setup(conn => conn.State).Returns(System.Data.ConnectionState.Open);
        var mockCommand = new Mock<SqlCommand>();
        mockConnection.Setup(conn => conn.CreateCommand()).Returns(mockCommand.Object);
        mockCommand.Setup(cmd => cmd.ExecuteReader()).Returns(new SqlDataReader { HasRows = false });
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Get(1));
    }
}