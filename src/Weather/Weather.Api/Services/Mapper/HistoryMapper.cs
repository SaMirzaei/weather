namespace Weather.Api.Services.Mapper
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using Weather.Api.V1.Models;
    using Weather.Api.V1.Models.OpenWeatherMap;
    using Weather.Data.Entities;

    public class HistoryMapper : IMapper<Information, HistoryModel>
    {
        public HistoryModel Map(Information list)
        {
            var openWeatherMap = JsonConvert.DeserializeObject<OpenWeatherMap>(list.Json);

            var result = openWeatherMap.List.GroupBy(
                t => Convert.ToDateTime(t.DT_txt).Date,
                (key, g) =>
                    {
                        var item = openWeatherMap.List.Where(q => Convert.ToDateTime(q.DT_txt).Date == key).ToList();

                        return new HistoryModel
                        {
                            DateTime = key,
                            Humidity = item.Max(s => s.Main.Humidity),
                            Wind = (int)item.Max(s => s.Wind.Speed),
                            LowTemperature = (int)item.Max(s => s.Main.TempMin),
                            HighTemperature = (int)item.Max(s => s.Main.TempMax),
                            Description = item.Max(s => s.Weather.Max(q => q.Description))
                        };
                    });

            return result.FirstOrDefault();
        }
    }
}
