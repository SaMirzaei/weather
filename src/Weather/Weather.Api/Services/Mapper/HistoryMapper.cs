namespace Weather.Api.Services.Mapper
{
    using System;

    using Weather.Api.V1.Models;
    using Weather.Data.Entities;

    public class HistoryMapper : IMapper<Information, HistoryModel>
    {
        public HistoryModel Map(Information list)
        {
            return new HistoryModel
            {
                DateTime = DateTime.UtcNow,
                Humidity = 100,
                Wind = 200,
                LowTemperature = 100,
                HighTemperature = 150,
                Description = "Most cloudy"
            };
        }
    }
}
