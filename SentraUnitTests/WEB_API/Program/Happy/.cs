using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void ConfigureServices_AddsControllers()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });

        // Act
        builder.Services.AddControllers();
        var services = builder.Services.ToList();

        // Assert
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptorProvider));
    }

    [Fact]
    public void ConfigureServices_AddsEndpointsApiExplorer()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });

        // Act
        builder.Services.AddEndpointsApiExplorer();
        var services = builder.Services.ToList();

        // Assert
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.AspNetCore.Mvc.ApiExplorer.IEndpointRouteInfoProvider));
    }

    [Fact]
    public void ConfigureServices_AddsSwaggerGen()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });

        // Act
        builder.Services.AddSwaggerGen();
        var services = builder.Services.ToList();

        // Assert
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.OpenApi.Models.OpenApiDocument));
    }
}