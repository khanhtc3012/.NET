using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void ConfigureServices_AddsControllers()
    {
        var services = new ServiceCollection();
        var builder = new WebApplicationBuilder(new string[] { });

        builder.Services.ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        var controllerService = serviceProvider.GetService(typeof(Microsoft.AspNetCore.Mvc.Controllers.ControllerActivator));
        Assert.NotNull(controllerService);
    }

    [Fact]
    public void Configure_Development_EnablesSwagger()
    {
        var app = new WebApplication(new WebApplicationOptions { EnvironmentName = "Development" });
        var mockRequestDelegate = new RequestDelegate(_ => Task.CompletedTask);

        app.UseSwagger(mockRequestDelegate);
        app.UseSwaggerUI(mockRequestDelegate);

        var swaggerMiddleware = app.MiddlewareStack.FirstOrDefault(m => m.GetType().Name == "SwaggerMiddleware");
        var swaggerUIMiddleware = app.MiddlewareStack.FirstOrDefault(m => m.GetType().Name == "SwaggerUIMiddleware");

        Assert.NotNull(swaggerMiddleware);
        Assert.NotNull(swaggerUIMiddleware);
    }

    [Fact]
    public void Configure_Production_DisablesSwagger()
    {
        var app = new WebApplication(new WebApplicationOptions { EnvironmentName = "Production" });
        var mockRequestDelegate = new RequestDelegate(_ => Task.CompletedTask);

        app.UseSwagger(mockRequestDelegate);
        app.UseSwaggerUI(mockRequestDelegate);

        var swaggerMiddleware = app.MiddlewareStack.FirstOrDefault(m => m.GetType().Name == "SwaggerMiddleware");
        var swaggerUIMiddleware = app.MiddlewareStack.FirstOrDefault(m => m.GetType().Name == "SwaggerUIMiddleware");

        Assert.Null(swaggerMiddleware);
        Assert.Null(swaggerUIMiddleware);
    }
}