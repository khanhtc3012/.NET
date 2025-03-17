using System;
using Xunit;

namespace WEB_API.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void Constructor_WithValidParameters_SetsPropertiesCorrectly()
        {
            // Arrange
            DateTime date = new DateTime(2023, 10, 1);
            int temperatureC = 20;
            string summary = "Sunny";

            // Act
            var forecast = new WeatherForecast
            {
                Date = date,
                TemperatureC = temperatureC,
                Summary = summary
            };

            // Assert
            Assert.Equal(date, forecast.Date);
            Assert.Equal(temperatureC, forecast.TemperatureC);
            Assert.Equal(32 + (int)(temperatureC / 0.5556), forecast.TemperatureF);
            Assert.Equal(summary, forecast.Summary);
        }

        [Fact]
        public void TemperatureF_CalculatesCorrectly()
        {
            // Arrange
            var forecast = new WeatherForecast
            {
                TemperatureC = 20
            };

            // Act
            int temperatureF = forecast.TemperatureF;

            // Assert
            Assert.Equal(68, temperatureF);
        }

        [Fact]
        public void DefaultConstructor_SetsDefaultValues()
        {
            // Arrange & Act
            var forecast = new WeatherForecast();

            // Assert
            Assert.Equal(DateTime.MinValue, forecast.Date);
            Assert.Equal(0, forecast.TemperatureC);
            Assert.Equal(32, forecast.TemperatureF);
            Assert.Null(forecast.Summary);
        }
    }
}