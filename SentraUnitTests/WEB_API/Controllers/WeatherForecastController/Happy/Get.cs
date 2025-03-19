using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsIEnumerableOfWeatherForecast()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void Get_EachForecastHasValidDateAndSummary()
    {
        // Arrange
        var controller = new WeatherForecastController();
        var result = controller.Get().ToList();

        // Act & Assert
        foreach (var forecast in result)
        {
            Assert.NotEqual(DateTime.MinValue, forecast.Date);
            Assert.NotEmpty(forecast.Summary);
        }
    }

    [Fact]
    public void Get_TemperatureCWithinExpectedRange()
    {
        // Arrange
        var controller = new WeatherForecastController();
        var result = controller.Get().ToList();

        // Act & Assert
        foreach (var forecast in result)
        {
            Assert.InRange(forecast.TemperatureC, -20, 55);
        }
    }
}