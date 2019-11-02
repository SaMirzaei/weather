namespace Weather.Api.Services.Abstracts
{
    using System.Collections.Generic;

    using Weather.Api.V1.Models;

    public interface IWeatherService
    {
        IEnumerable<WeatherModel> GetByCity(string city);

        IEnumerable<WeatherModel> GetByZipCide(string zipCode);

        IEnumerable<HistoryModel> GetHistory(string city);
    }
}
