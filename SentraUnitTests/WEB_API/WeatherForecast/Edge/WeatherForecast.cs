using System;
using Xunit;

namespace WEB_API.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void SetDate_WithMinimumDateTime_UpdatesDateProperty()
        {
            // Arrange
            var forecast = new WeatherForecast();
            var minDateTime = DateTime.MinValue;

            // Act
            forecast.Date = minDateTime;

            // Assert
            Assert.Equal(minDateTime, forecast.Date);
        }

        [Fact]
        public void SetDate_WithMaximumDateTime_UpdatesDateProperty()
        {
            // Arrange
            var forecast = new WeatherForecast();
            var maxDateTime = DateTime.MaxValue;

            // Act
            forecast.Date = maxDateTime;

            // Assert
            Assert.Equal(maxDateTime, forecast.Date);
        }

        [Fact]
        public void GetTemperatureF_WithExtremeNegativeTemperatureC_ReturnsCorrectTemperatureF()
        {
            // Arrange
            var forecast = new WeatherForecast { TemperatureC = -100 };

            // Act
            var temperatureF = forecast.TemperatureF;

            // Assert
            Assert.Equal(-148, temperatureF);
        }
    }
}