namespace Weather.Api.Services.Mapper
{
    using System.Collections.Generic;

    using Weather.Api.V1.Models;
    using Weather.Api.V1.Models.OpenWeatherMap;

    public class OpenWeatherMapper : IMapper<OpenWeatherMap, List<WeatherModel>>
    {
        public List<WeatherModel> Map(OpenWeatherMap instance)
        {
            var result = new List<WeatherModel>
            {
                new WeatherModel { Coutnry = "IR", City = "Tehran", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "US", City = "United State", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "UK", City = "United Kingdom", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "GR", City = "Germany", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "MB", City = "Melborn", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "CD", City = "Combugieh", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
            };

            return result;
        }
    }
}
