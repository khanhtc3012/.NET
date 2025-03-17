using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void TestCreateBuilder()
    {
        // Arrange
        var args = new string[] { };

        // Act
        var builder = WebApplication.CreateBuilder(args);

        // Assert
        Assert.NotNull(builder);
        Assert.NotNull(builder.Services);
    }

    [Fact]
    public void TestConfigureServices()
    {
        // Arrange
        var args = new string[] { };
        var builder = WebApplication.CreateBuilder(args);

        // Act
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Assert
        Assert.Collection(builder.Services,
            service => Assert.Equal(typeof(MvcServiceCollectionExtensions).FullName, service.ServiceType.FullName),
            service => Assert.Equal(typeof(EndpointsRoutingServiceCollectionExtensions).FullName, service.ServiceType.FullName),
            service => Assert.Equal(typeof(SwaggerGenServiceCollectionExtensions).FullName, service.ServiceType.FullName));
    }

    [Fact]
    public void TestBuildAndRun()
    {
        // Arrange
        var args = new string[] { };
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        // Act & Assert
        Assert.NotNull(app);
        Assert.Throws<InvalidOperationException>(() => app.Run());
    }
}