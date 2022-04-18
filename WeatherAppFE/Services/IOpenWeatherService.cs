using WeatherApp.Models;

namespace WeatherApp.Services
{
    public interface IOpenWeatherService
    {
        public Task<WeatherForecastModel?> GetWeatherForcast(string lat, string lon);
    }
}
