namespace Weather.Api.Services.Mapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Weather.Api.V1.Models;
    using Weather.Api.V1.Models.OpenWeatherMap;

    public class OpenWeatherMapper : IMapper<OpenWeatherMap, IEnumerable<WeatherModel>>
    {
        public IEnumerable<WeatherModel> Map(OpenWeatherMap instance)
        {
            var result = instance.List.GroupBy(
                t => Convert.ToDateTime(t.DT_txt).Date,
                (key, g) =>
                    {
                        var item = instance.List.Where(q => Convert.ToDateTime(q.DT_txt).Date == key).ToList();

                        return new WeatherModel
                        {
                            DateTime = key,
                            City = instance.City.Name,
                            Coutnry = instance.City.Country,
                            Wind = (int)item.Max(s => s.Wind.Speed),
                            Humidity = item.Max(s => s.Main.Humidity),
                            MaxTemperature = item.Max(s => s.Main.TempMax),
                            MinTemperature = item.Max(s => s.Main.TempMin)
                        };
                    });

            return result;
        }
    }
}
