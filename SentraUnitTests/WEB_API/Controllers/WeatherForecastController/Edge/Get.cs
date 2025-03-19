using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsFiveForecasts()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<IEnumerable<WeatherForecast>>(result);
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void Get_ForecastDateIsCorrect()
    {
        // Arrange
        var controller = new WeatherForecastController();
        var now = DateTime.UtcNow;

        // Act
        var result = controller.Get();

        // Assert
        Assert.All(result, forecast => 
        {
            Assert.True(forecast.Date >= now && forecast.Date <= now.AddDays(5));
        });
    }

    [Fact]
    public void Get_TemperatureRangeIsValid()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.All(result, forecast => 
        {
            Assert.InRange(forecast.TemperatureC, -20, 55);
        });
    }
}