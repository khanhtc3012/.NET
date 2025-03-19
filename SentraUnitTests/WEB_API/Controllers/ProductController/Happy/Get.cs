using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace WEB_API.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly string _connectionString = "Server=.;Database=TestDB;Trusted_Connection=True;";

        [Fact]
        public async Task Get_ReturnsEmptyList_WhenNoProductsExist()
        {
            // Arrange
            var controller = new ProductController();
            controller.DatabaseContext = new TestDbContext();

            // Act
            var result = await controller.Get();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task Get_ReturnsListOfProducts_WhenProductsExist()
        {
            // Arrange
            var controller = new ProductController();
            controller.DatabaseContext = new TestDbContext();
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product1" },
                new Product { Id = 2, Name = "Product2" }
            };
            controller.DatabaseContext.Products.AddRange(products);
            controller.DatabaseContext.SaveChanges();

            // Act
            var result = await controller.Get();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains("Product1", result.Select(p => p.Name));
            Assert.Contains("Product2", result.Select(p => p.Name));
        }

        [Fact]
        public async Task Get_ReturnsCorrectProductDetails_WhenValidIdProvided()
        {
            // Arrange
            var controller = new ProductController();
            controller.DatabaseContext = new TestDbContext();
            var product = new Product { Id = 1, Name = "Product1", Price = 10.99m };
            controller.DatabaseContext.Products.Add(product);
            controller.DatabaseContext.SaveChanges();

            // Act
            var result = await controller.Get(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Product1", result.Name);
            Assert.Equal(10.99m, result.Price);
        }
    }
}