using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class WeatherForecastModel
    {
        public string Name { get; set; }

        public Weather Main { get; set; }

        public Trivia Sys { get; set; }

    }

    public class Weather
    {
        public double Temp { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        public double Humidity { get; set; }

        public double Pressure { get; set; }
    }

    public class Trivia
    {
        public string Country { get; set; }

        public int Sunrise { get; set; }

        public int Sunset { get; set; }

        public string ConvertedSunrise
        {
            get
            {
                return DateTime.UnixEpoch.AddSeconds(this.Sunrise).ToLocalTime().ToString();
            }
        }

        public string ConvertedSunset
        {
            get
            {
                return DateTime.UnixEpoch.AddSeconds(this.Sunset).ToLocalTime().ToString();
            }
        }
    }
}
