using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class StartupTests
{
    [Fact]
    public void ConfigureServices_RegistersControllers()
    {
        // Arrange
        var builder = new WebApplicationBuilder(new string[] { });
        
        // Act
        builder.Services.AddControllers();
        
        // Assert
        var services = builder.Services.ToList();
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.AspNetCore.Mvc.Controllers.ControllerActivator));
    }

    [Fact]
    public void ConfigureServices_RegistersSwagger()
    {
        // Arrange
        var builder = new WebApplicationBuilder(new string[] { });

        // Act
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Assert
        var services = builder.Services.ToList();
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.OpenApi.Models.OpenApiInfo));
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.OpenApi.Models.OpenApiDocument));
    }

    [Fact]
    public void Configure_DevelopmentEnvironment_EnablesSwaggerAndUI()
    {
        // Arrange
        var builder = new WebApplicationBuilder(new string[] { });
        builder.WebHost.UseUrls("http://localhost");
        builder.WebHost.ConfigureKestrel((context, options) => { });
        builder.WebHost.ConfigureAppConfiguration((context, config) => { });
        builder.WebHost.ConfigureServices((context, services) => { });
        builder.WebHost.ConfigureLogging((context, logging) => { });
        builder.WebHost.UseStartup<Startup>();
        builder.Environment.IsDevelopment = true;

        var app = builder.Build();

        // Act
        app.UseSwagger();
        app.UseSwaggerUI();

        // Assert
        var middleware = app.Middlewares.ToArray();
        Assert.Contains(middleware, m => m.GetType().Name == "UseSwaggerMiddleware");
        Assert.Contains(middleware, m => m.GetType().Name == "UseSwaggerUIMiddleware");
    }
}