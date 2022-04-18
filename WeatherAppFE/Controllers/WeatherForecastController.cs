using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherForecastController : Controller
    {
        public IOpenWeatherService OpenWeatherService { get; set; }

        public WeatherForecastController()
        {
            OpenWeatherService = new OpenWeatherService();
        }

        [HttpGet]
        public IActionResult Forecast()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Forecast([Required]string lat,[Required] string lon)
        {
            WeatherForecastModel? forcast = await OpenWeatherService.GetWeatherForcast(lat, lon);
            if (forcast == null)
            {
                ViewBag.IsError = true;
                return View();
            }
            return View(forcast);
        }
    }
}