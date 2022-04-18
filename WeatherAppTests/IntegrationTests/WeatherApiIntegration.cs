using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using WeatherApp.Controllers;
using WeatherApp.Models;

namespace WeatherAppTests
{
    [TestClass]
    public class WeatherControllerIntegrationTests
    {
        [TestMethod]
        public async Task TestWeatherControllerSuccess()
        {
            string lat = "54.9783";
            string lon = "1.6178";

            
            var controller = new WeatherForecastController();

            var response = await controller.Forecast(lat, lon);

            var objResponse = response as ViewResult;
            Assert.IsNotNull(response);
            var responseData = objResponse.Model as WeatherForecastModel;
            Assert.IsNotNull(responseData);
            Assert.AreEqual(responseData.Name, "Flamborough");
            Assert.AreEqual(responseData.Sys.Country, "GB");
        }
    }
}
