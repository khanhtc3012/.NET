using NUnit.Framework;
using WEB_API.Controllers;
using WEB_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

[TestFixture]
public class ProductControllerTests
{
    private ProductController _controller;
    private string _connectionString;

    [SetUp]
    public void Setup()
    {
        _connectionString = "Server=.;Database=TestDB;Trusted_Connection=True;";
        _controller = new ProductController();
    }

    [Test]
    public async Task Get_ReturnsEmptyList_WhenNoProductsInDatabase()
    {
        // Arrange
        using (var conn = new SqlConnection(_connectionString))
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            var commandText = "SELECT * FROM Products";
            var parameters = null;
            var transaction = null;
            var commandType = System.Data.CommandType.Text;

            conn.Execute(commandText, parameters, transaction, commandTimeout: null, commandType: commandType);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsEmpty(result);
        }
    }

    [Test]
    public async Task Get_ReturnsListOfProducts_WhenProductsExistInDatabase()
    {
        // Arrange
        var product1 = new Product { Id = 1, Name = "Product1" };
        var product2 = new Product { Id = 2, Name = "Product2" };

        using (var conn = new SqlConnection(_connectionString))
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            var commandText = "INSERT INTO Products (Id, Name) VALUES (@Id, @Name)";
            var parameters = new[]
            {
                new { Id = product1.Id, Name = product1.Name },
                new { Id = product2.Id, Name = product2.Name }
            };
            var transaction = null;
            var commandType = System.Data.CommandType.Text;

            conn.Execute(commandText, parameters, transaction, commandTimeout: null, commandType: commandType);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Contains(product1));
            Assert.IsTrue(result.Contains(product2));
        }
    }

    [TearDown]
    public void TearDown()
    {
        // Clean up database after each test
        using (var conn = new SqlConnection(_connectionString))
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            var commandText = "DELETE FROM Products";
            var parameters = null;
            var transaction = null;
            var commandType = System.Data.CommandType.Text;

            conn.Execute(commandText, parameters, transaction, commandTimeout: null, commandType: commandType);
        }
    }
}