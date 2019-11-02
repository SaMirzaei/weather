namespace Weather.Api.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        private readonly IMapper<OpenWeatherMap, List<WeatherModel>> _openWeatherMapper;

        private readonly IMapper<Information, HistoryModel> _historyMapper;

        public WeatherService(
            IRestClientProxy restClientProxy,
            ApiContext apiContext,
            Func<DateTime> now,
            IMapper<OpenWeatherMap, List<WeatherModel>> openWeatherMapper,
            IMapper<Information, HistoryModel> historyMapper)
        {
            _restClientProxy = restClientProxy;
            _apiContext = apiContext;
            _now = now;
            _openWeatherMapper = openWeatherMapper;
            _historyMapper = historyMapper;
        }

        public IEnumerable<WeatherModel> GetByCity(string city)
        {
            var data = _restClientProxy
                .Setup(t =>
                {
                    t.Parameters.Add(new Parameter("q", city, ParameterType.QueryString));
                })
                .Execute<OpenWeatherMap>();

            if (data?.Value == null)
            {
                return null;
            }

            SaveData(data.Value);

            return _openWeatherMapper.Map(data.Value);
        }

        public IEnumerable<WeatherModel> GetByZipCide(string zipCode)
        {
            var data = _restClientProxy
                .Setup(t =>
                {
                    t.Parameters.Add(new Parameter("zip", zipCode, ParameterType.QueryString));
                })
                .Execute<OpenWeatherMap>();

            if (data?.Value == null)
            {
                return null;
            }

            SaveData(data.Value);

            return _openWeatherMapper.Map(data.Value);
        }

        public IEnumerable<HistoryModel> GetHistory(string city)
        {
            var result = _apiContext.Informations
                .Where(t => t.City == city.ToLower().Trim())
                // .Select(t => JsonConvert.DeserializeObject<OpenWeatherMap>(t.Json))
                .ToList();

            return result.Select(_historyMapper.Map);
        }

        private void SaveData(OpenWeatherMap openWeatherMap)
        {
            if (openWeatherMap == null)
            {
                throw new NullReferenceException(nameof(openWeatherMap));
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
