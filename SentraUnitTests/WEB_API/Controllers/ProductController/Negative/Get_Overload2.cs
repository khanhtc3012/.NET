using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WEB_API.Models;
using Dapper;
using Xunit;

public class ProductControllerTests
{
    [Fact]
    public async Task Get_ThrowsExceptionOnInvalidId()
    {
        // Arrange
        var controller = new ProductController();
        var invalidId = -1; // Assuming negative IDs are considered invalid

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Get(invalidId));
    }

    [Fact]
    public async Task Get_ThrowsExceptionOnClosedConnection()
    {
        // Arrange
        var controller = new ProductController();
        var id = 1;
        using (var conn = new SqlConnection("Data Source=.;Initial Catalog=TestDB;Integrated Security=True"))
        {
            conn.Close();

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Get(id));
        }
    }

    [Fact]
    public async Task Get_ThrowsExceptionOnEmptyResult()
    {
        // Arrange
        var controller = new ProductController();
        var nonExistentId = 99999; // Assuming this ID does not exist in the database

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => controller.Get(nonExistentId));
    }
}