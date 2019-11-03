namespace Weather.Api.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using RestSharp;
    using RestSharp.Serialization.Json;

    using Weather.Api.Infrastructures.Abstracts;
    using Weather.Api.Services.Abstracts;
    using Weather.Api.Services.Mapper;
    using Weather.Api.V1.Models;
    using Weather.Api.V1.Models.OpenWeatherMap;
    using Weather.Data.Entities;

    public class WeatherService : IWeatherService
    {
        private readonly IRestClientProxy _restClientProxy;

        private readonly ApiContext _apiContext;

        private readonly Func<DateTime> _now;

        private readonly IMapper<OpenWeatherMap, IEnumerable<WeatherModel>> _openWeatherMapper;

        private readonly IMapper<Information, HistoryModel> _historyMapper;

        public WeatherService(
            IRestClientProxy restClientProxy,
            ApiContext apiContext,
            Func<DateTime> now,
            IMapper<OpenWeatherMap, IEnumerable<WeatherModel>> openWeatherMapper,
            IMapper<Information, HistoryModel> historyMapper)
        {
            _restClientProxy = restClientProxy;
            _apiContext = apiContext;
            _now = now;
            _openWeatherMapper = openWeatherMapper;
            _historyMapper = historyMapper;
        }

        public async Task<IEnumerable<WeatherModel>> GetByCity(string city, CancellationToken cancellationToken)
        {
            var data = await _restClientProxy
                .Setup(t =>
                {
                    t.Parameters.Add(new Parameter("q", city, ParameterType.QueryString));
                })
                .ExecuteAsync<OpenWeatherMap>(cancellationToken);

            if (data?.Value == null)
            {
                return null;
            }

            SaveData(data.Value);

            return _openWeatherMapper.Map(data.Value);
        }

        public async Task<IEnumerable<WeatherModel>> GetByZipCide(string zipCode, CancellationToken cancellationToken)
        {
            var data = await _restClientProxy
                .Setup(t =>
                {
                    t.Parameters.Add(new Parameter("zip", zipCode, ParameterType.QueryString));
                })
                .ExecuteAsync<OpenWeatherMap>(cancellationToken);

            if (data?.Value == null)
            {
                return null;
            }

            SaveData(data.Value);

            return _openWeatherMapper.Map(data.Value);
        }

        public async Task<IEnumerable<HistoryModel>> GetHistory(string city, CancellationToken cancellationToken)
        {
            var result = await _apiContext.Informations
                .Where(t => t.City == city.ToLower().Trim())
                .ToListAsync(cancellationToken);

            return result.Select(_historyMapper.Map);
        }

        private void SaveData(OpenWeatherMap openWeatherMap)
        {
            if (openWeatherMap == null)
            {
                throw new NullReferenceException(nameof(openWeatherMap));
            }

            if (_apiContext.Informations.Any(t => 
                t.CreatedAt.Date == _now().Date && 
                t.Country.ToLower().Trim() == openWeatherMap.City.Country.ToLower().Trim() && 
                t.City.ToLower().Trim() == openWeatherMap.City.Name.ToLower().Trim()))
            {
                return;
            }

            _apiContext.Informations.Add(new Information
            {
                Id = Guid.NewGuid(),
                CreatedAt = _now(),
                Country = openWeatherMap.City.Country.ToLower().Trim(),
                City = openWeatherMap.City.Name.ToLower().Trim(),
                Json = new JsonDeserializer().Serialize(openWeatherMap)
            });

            _apiContext.SaveChanges();
        }
    }
}
