using System.Text.Json;

using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class OpenWeatherService: IOpenWeatherService
    {
        static readonly HttpClient client = new HttpClient();

        private const string BASE_URL = "https://api.openweathermap.org/data/2.5";
        private static string API_TOKEN = "50f68b9179eb43ad83bdca3ec7b175b5";
        private static string CURRENT_WEATHER_URL = $"{BASE_URL}/weather?units=metric&lat={{0}}&lon={{1}}&appid={API_TOKEN}";

        public async Task<WeatherForecastModel?> GetWeatherForcast(string lat, string lon)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(String.Format(CURRENT_WEATHER_URL, lat, lon), null);
                response.EnsureSuccessStatusCode();
                string jsonString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
                return JsonSerializer.Deserialize<WeatherForecastModel>(jsonString, options);
            }
            catch (HttpRequestException e)
            {
                Console.Error.WriteLine($"Request failed: {e.Message}");
                return null;
            }
        }
    }
}
