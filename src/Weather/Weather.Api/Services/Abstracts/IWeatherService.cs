namespace Weather.Api.Services.Abstracts
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using Weather.Api.V1.Models;

    public interface IWeatherService
    {
        Task<IEnumerable<WeatherModel>> GetByCity(string city, CancellationToken cancellationToken);

        Task<IEnumerable<WeatherModel>> GetByZipCide(string zipCode, CancellationToken cancellationToken);

        Task<IEnumerable<HistoryModel>> GetHistory(string city, CancellationToken cancellationToken);
    }
}
