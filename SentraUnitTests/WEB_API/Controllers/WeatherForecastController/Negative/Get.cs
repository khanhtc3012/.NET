using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsEmptyArray_WhenInputIsInvalid()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = controller.Get() as IActionResult;
        var contentResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(contentResult);
        Assert.IsType<List<WeatherForecast>>(contentResult.Value);
        Assert.Empty((List<WeatherForecast>)contentResult.Value);
    }

    [Fact]
    public void Get_ThrowsArgumentNullException_WhenInputIsNull()
    {
        // Arrange
        var controller = new WeatherForecastController();
        controller.ModelState.AddModelError("error", "Invalid input");

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => controller.Get());
        Assert.Equal("Invalid input", exception.Message);
    }

    [Fact]
    public void Get_ThrowsInvalidOperationException_WhenInputIsEmpty()
    {
        // Arrange
        var controller = new WeatherForecastController();
        controller.ModelState.AddModelError("error", "Invalid input");

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => controller.Get());
        Assert.Equal("Invalid input", exception.Message);
    }
}