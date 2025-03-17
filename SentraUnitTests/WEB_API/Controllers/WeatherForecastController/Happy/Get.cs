using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

public class WeatherForecastControllerTests
{
    [Fact]
    public void Get_ReturnsFiveWeatherForecasts()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = controller.Get() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<IEnumerable<WeatherForecast>>(result.Value);
        Assert.Equal(5, ((IEnumerable<WeatherForecast>)result.Value).Count());
    }

    [Fact]
    public void Get_EachForecastHasValidProperties()
    {
        // Arrange
        var controller = new WeatherForecastController();
        var result = controller.Get() as OkObjectResult;
        var forecasts = (IEnumerable<WeatherForecast>)result.Value;

        // Assert
        foreach (var forecast in forecasts)
        {
            Assert.NotEqual(default(DateTime), forecast.Date);
            Assert.InRange(forecast.TemperatureC, -20, 55);
            Assert.NotEmpty(forecast.Summary);
        }
    }

    [Fact]
    public void Get_ReturnsOkStatusCode()
    {
        // Arrange
        var controller = new WeatherForecastController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}