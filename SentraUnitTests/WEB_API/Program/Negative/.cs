using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit;

public class WebApplicationTests
{
    [Fact]
    public void ConfigureServices_WithNullThrowsArgumentNullException()
    {
        // Arrange
        var args = new string[] { };

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => WebApplication.CreateBuilder(null));
    }

    [Fact]
    public void Run_WithNullThrowsArgumentNullException()
    {
        // Arrange
        var builder = WebApplication.CreateBuilder(new string[] { });

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.Build().Run(null));
    }
}