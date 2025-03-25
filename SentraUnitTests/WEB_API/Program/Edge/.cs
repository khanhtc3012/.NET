using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class WebApplicationBuilderTests
{
    [Fact]
    public void ConfigureServices_AddsControllers()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });

        // Act
        builder.Services.AddControllers();

        // Assert
        var serviceDescriptor = builder.Services.FirstOrDefault(d => d.ServiceType == typeof(Microsoft.AspNetCore.Mvc.Controllers.ControllerActionInvokerProvider));
        Assert.NotNull(serviceDescriptor);
    }

    [Fact]
    public void ConfigureServices_AddsEndpointsApiExplorer()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });

        // Act
        builder.Services.AddEndpointsApiExplorer();

        // Assert
        var serviceDescriptor = builder.Services.FirstOrDefault(d => d.ServiceType == typeof(Microsoft.OpenApi.Models.OpenApiDocument));
        Assert.NotNull(serviceDescriptor);
    }

    [Fact]
    public void ConfigureServices_AddsSwaggerGen()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });

        // Act
        builder.Services.AddSwaggerGen();

        // Assert
        var serviceDescriptor = builder.Services.FirstOrDefault(d => d.ServiceType == typeof(SwaggerConfigurator));
        Assert.NotNull(serviceDescriptor);
    }
}