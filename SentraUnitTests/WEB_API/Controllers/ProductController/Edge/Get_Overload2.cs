using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WEB_API.Models;
using Dapper;
using Xunit;

public class ProductControllerTests
{
    private readonly string _connectionString = "Server=.;Database=TestDB;Trusted_Connection=True;";

    [Fact]
    public async Task Get_ThrowsExceptionOnClosedConnection()
    {
        // Arrange
        var controller = new ProductController();
        var id = 1;

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Get(id));
    }

    [Fact]
    public async Task Get_ThrowsExceptionOnEmptyResult()
    {
        // Arrange
        var controller = new ProductController();
        var id = 999; // Assuming 999 is an ID that does not exist in the database

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Get(id));
    }

    [Fact]
    public async Task Get_ThrowsExceptionOnInvalidId()
    {
        // Arrange
        var controller = new ProductController();
        var id = int.MinValue;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => controller.Get(id));
    }
}