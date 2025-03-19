using Xunit;
using System;

namespace WEB_API.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void Constructor_WithNullDate_ShouldThrowArgumentNullException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new WeatherForecast { Date = null });
        }

        [Fact]
        public void Constructor_WithNegativeTemperatureC_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new WeatherForecast { TemperatureC = -274 });
        }
    }
}