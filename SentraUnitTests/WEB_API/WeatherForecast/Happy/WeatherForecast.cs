using Xunit;
using System;

namespace WEB_API.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void Constructor_WithValidInputs_SetsPropertiesCorrectly()
        {
            // Arrange
            var date = new DateTime(2023, 10, 1);
            var temperatureC = 25;
            var summary = "Sunny";

            // Act
            var weatherForecast = new WeatherForecast
            {
                Date = date,
                TemperatureC = temperatureC,
                Summary = summary
            };

            // Assert
            Assert.Equal(date, weatherForecast.Date);
            Assert.Equal(temperatureC, weatherForecast.TemperatureC);
            Assert.Equal(32 + (int)(temperatureC / 0.5556), weatherForecast.TemperatureF);
            Assert.Equal(summary, weatherForecast.Summary);
        }

        [Fact]
        public void TemperatureF_CalculatesCorrectly()
        {
            // Arrange
            var weatherForecast = new WeatherForecast
            {
                TemperatureC = 25
            };

            // Act
            var temperatureF = weatherForecast.TemperatureF;

            // Assert
            Assert.Equal(77, temperatureF);
        }

        [Fact]
        public void DefaultValues_AreInitializedCorrectly()
        {
            // Arrange
            var weatherForecast = new WeatherForecast();

            // Assert
            Assert.Null(weatherForecast.Date);
            Assert.Equal(0, weatherForecast.TemperatureC);
            Assert.Equal(32, weatherForecast.TemperatureF);
            Assert.Null(weatherForecast.Summary);
        }
    }
}