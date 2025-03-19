using Xunit;

namespace WEB_API.Tests
{
    public class WeatherForecastTests
    {
        [Fact]
        public void WeatherForecast_CelsiusToFahrenheitConversion()
        {
            // Arrange
            var forecast = new WeatherForecast { TemperatureC = 0 };

            // Act
            var temperatureF = forecast.TemperatureF;

            // Assert
            Assert.Equal(32, temperatureF);
        }

        [Fact]
        public void WeatherForecast_NegativeCelsiusToFahrenheitConversion()
        {
            // Arrange
            var forecast = new WeatherForecast { TemperatureC = -40 };

            // Act
            var temperatureF = forecast.TemperatureF;

            // Assert
            Assert.Equal(-40, temperatureF);
        }

        [Fact]
        public void WeatherForecast_MaximumCelsiusToFahrenheitConversion()
        {
            // Arrange
            var forecast = new WeatherForecast { TemperatureC = 100 };

            // Act
            var temperatureF = forecast.TemperatureF;

            // Assert
            Assert.Equal(212, temperatureF);
        }
    }
}