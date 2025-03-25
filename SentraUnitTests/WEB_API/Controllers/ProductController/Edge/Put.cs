using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Data.SqlClient;
using WEB_API.Models;
using Dapper;
using Xunit;

public class ProductControllerTests
{
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly string _connectionString;

    public ProductControllerTests()
    {
        _configurationMock = new Mock<IConfiguration>();
        _connectionString = "Server=.;Database=TestDB;Trusted_Connection=True;";
        _configurationMock.Setup(c => c.GetConnectionString("DefaultConnection")).Returns(_connectionString);
    }

    [Fact]
    public async Task Put_WithMinimumId_UpdatesProduct()
    {
        // Arrange
        var controller = new ProductController(_configurationMock.Object);
        var product = new Product { Sku = "SKU123", Content = "Content", Price = 10.0m, IsActive = true, ImageUrl = "image.jpg" };
        int minId = 1;

        // Act
        await controller.Put(minId, product);

        // Assert
        using (var conn = new SqlConnection(_connectionString))
        {
            var updatedProduct = await conn.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @id", new { id = minId });
            Assert.NotNull(updatedProduct);
            Assert.Equal(product.Sku, updatedProduct.Sku);
            Assert.Equal(product.Content, updatedProduct.Content);
            Assert.Equal(product.Price, updatedProduct.Price);
            Assert.Equal(product.IsActive, updatedProduct.IsActive);
            Assert.Equal(product.ImageUrl, updatedProduct.ImageUrl);
        }
    }

    [Fact]
    public async Task Put_WithMaximumId_UpdatesProduct()
    {
        // Arrange
        var controller = new ProductController(_configurationMock.Object);
        var product = new Product { Sku = "SKU123", Content = "Content", Price = 10.0m, IsActive = true, ImageUrl = "image.jpg" };
        int maxId = int.MaxValue;

        // Act
        await controller.Put(maxId, product);

        // Assert
        using (var conn = new SqlConnection(_connectionString))
        {
            var updatedProduct = await conn.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @id", new { id = maxId });
            Assert.NotNull(updatedProduct);
            Assert.Equal(product.Sku, updatedProduct.Sku);
            Assert.Equal(product.Content, updatedProduct.Content);
            Assert.Equal(product.Price, updatedProduct.Price);
            Assert.Equal(product.IsActive, updatedProduct.IsActive);
            Assert.Equal(product.ImageUrl, updatedProduct.ImageUrl);
        }
    }

    [Fact]
    public async Task Put_WithNegativeId_ThrowsArgumentException()
    {
        // Arrange
        var controller = new ProductController(_configurationMock.Object);
        var product = new Product { Sku = "SKU123", Content = "Content", Price = 10.0m, IsActive = true, ImageUrl = "image.jpg" };
        int negativeId = -1;

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => controller.Put(negativeId, product));
    }
}