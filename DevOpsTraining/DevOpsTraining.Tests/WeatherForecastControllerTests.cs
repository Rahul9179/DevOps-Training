using Moq;
using DevOpsTraining.Controllers;
using Microsoft.Extensions.Logging;

namespace DevOpsTraining.Tests
{
    public class WeatherForecastControllerTests
    {
        private WeatherForecastController _controller;
        private Mock<ILogger<WeatherForecastController>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(_mockLogger.Object);
        }

        [Test]
        public void GetForecast_ReturnsValidForecasts()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void GetForecast_ReturnsForecasts_WithValidProperties()
        {
            // Act
            var result = _controller.Get().ToList();

            // Asser!
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.First().TemperatureC , Is.Not.Null);
            Assert.That(result.First().Summary, Is.Not.Null.And.Not.Empty);
        }

        [Test]
        public void GetForecast_ReturnsForecasts_WithValidDates()
        {
            // Act
            var result = _controller.Get().ToList();

            // Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.First().Date, Is.TypeOf<DateOnly>());
        }
    }
}
