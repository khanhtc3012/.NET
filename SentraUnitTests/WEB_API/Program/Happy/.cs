using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

public class WebApplicationTests
{
    [Fact]
    public void ConfigureServices_AddsControllers()
    {
        // Arrange
        var builder = new WebApplicationBuilder(new string[] { });

        // Act
        builder.Services.AddControllers();

        // Assert
        var serviceCollection = builder.Services.ToList();
        Assert.Contains(serviceCollection, s => s.ServiceType == typeof(Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptorProvider));
    }

    [Fact]
    public void ConfigureServices_AddsEndpointsApiExplorer()
    {
        // Arrange
        var builder = new WebApplicationBuilder(new string[] { });

        // Act
        builder.Services.AddEndpointsApiExplorer();

        // Assert
        var serviceCollection = builder.Services.ToList();
        Assert.Contains(serviceCollection, s => s.ServiceType == typeof(Microsoft.OpenApi.Models.OpenApiInfo));
    }

    [Fact]
    public void ConfigureServices_AddsSwaggerGen()
    {
        // Arrange
        var builder = new WebApplicationBuilder(new string[] { });

        // Act
        builder.Services.AddSwaggerGen();

        // Assert
        var serviceCollection = builder.Services.ToList();
        Assert.Contains(serviceCollection, s => s.ServiceType == typeof(SwaggerGenOptions));
    }
}