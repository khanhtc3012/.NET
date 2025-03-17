using System;
using Xunit;

namespace WEB_API.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void Constructor_WithInvalidDateTime_ShouldThrowArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new WeatherForecast { Date = DateTime.MinValue });
        }

        [Fact]
        public void Constructor_WithNullSummary_ShouldNotThrowException()
        {
            // Arrange
            var forecast = new WeatherForecast { Date = DateTime.Now, TemperatureC = 25, Summary = null };

            // Act & Assert
            Assert.Null(forecast.Summary);
        }

        [Fact]
        public void TemperatureF_CalculatesCorrectly()
        {
            // Arrange
            var forecast = new WeatherForecast { TemperatureC = 25 };

            // Act
            var temperatureF = forecast.TemperatureF;

            // Assert
            Assert.Equal(77, temperatureF);
        }
    }
}