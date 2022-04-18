using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Services;
using WeatherApp.Controllers;
using WeatherApp.Models;
using Moq.Protected;
using Microsoft.AspNetCore.Mvc;

namespace WeatherAppTests
{
    [TestClass]
    public class WeatherControllerUnitTests
    {
        [TestMethod]
        public async Task TestWeatherControllerSuccess()
        {
            string lat = "54.9783";
            string lon = "1.6178";

            WeatherForecastModel mockResponse = new WeatherForecastModel
            {
                Name = "Name",
                Main = new Weather
                {
                    Temp = 20,
                    TempMax = 21,
                    TempMin = 19,
                    Humidity = 100,
                    Pressure = 200
                },
                Sys = new Trivia
                {
                    Country = "GB",
                    Sunrise = 10000,
                    Sunset = 12000
                }
            };

            var mockWeatherService = new Mock<IOpenWeatherService>();
            mockWeatherService.Setup(x => x.GetWeatherForcast(lat.ToString(), lon.ToString())).ReturnsAsync(mockResponse);
            var controller = new WeatherForecastController();
            controller.OpenWeatherService = mockWeatherService.Object;

            var response = await controller.Forecast(lat, lon) as ViewResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Model, mockResponse);
        }

        [TestMethod]
        public async Task TestWeatherControllerFailure()
        {
            string lat = "54.9783";
            string lon = "1.6178";

            WeatherForecastModel mockResponse = null;

            var mockWeatherService = new Mock<IOpenWeatherService>();
            mockWeatherService.Setup(x => x.GetWeatherForcast(lat.ToString(), lon.ToString())).ReturnsAsync(mockResponse);
            var controller = new WeatherForecastController();
            controller.OpenWeatherService = mockWeatherService.Object;

            var response = await controller.Forecast(lat, lon) as ViewResult;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Model, null);
        }
    }
}