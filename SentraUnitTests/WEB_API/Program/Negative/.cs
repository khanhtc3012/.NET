using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class WebApplicationBuilderTests
{
    [Fact]
    public void ConfigureServices_AddsControllers()
    {
        var builder = WebApplication.CreateBuilder(new string[] { });
        builder.Services.AddControllers();
        var services = builder.Services;
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor));
    }

    [Fact]
    public void ConfigureServices_AddsEndpointsApiExplorer()
    {
        var builder = WebApplication.CreateBuilder(new string[] { });
        builder.Services.AddEndpointsApiExplorer();
        var services = builder.Services;
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.OpenApi.Models.OpenApiInfo));
    }

    [Fact]
    public void ConfigureServices_AddsSwaggerGen()
    {
        var builder = WebApplication.CreateBuilder(new string[] { });
        builder.Services.AddSwaggerGen();
        var services = builder.Services;
        Assert.Contains(services, s => s.ServiceType == typeof(Microsoft.OpenApi.Models.OpenApiDocument));
    }
}