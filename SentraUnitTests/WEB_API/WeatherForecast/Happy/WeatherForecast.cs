using System;
using NUnit.Framework;

namespace WEB_API.Tests
{
    [TestFixture]
    public class WeatherForecastTests
    {
        [Test]
        public void WeatherForecast_Ctor_InitializesProperties()
        {
            // Arrange
            var date = DateTime.Now;
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
            Assert.AreEqual(date, weatherForecast.Date);
            Assert.AreEqual(temperatureC, weatherForecast.TemperatureC);
            Assert.AreEqual(32 + (int)(temperatureC / 0.5556), weatherForecast.TemperatureF);
            Assert.AreEqual(summary, weatherForecast.Summary);
        }

        [Test]
        public void WeatherForecast_TemperatureF_CalculatesCorrectly()
        {
            // Arrange
            var weatherForecast = new WeatherForecast
            {
                TemperatureC = 25
            };

            // Act
            var temperatureF = weatherForecast.TemperatureF;

            // Assert
            Assert.AreEqual(32 + (int)(25 / 0.5556), temperatureF);
        }
    }
}