namespace Weather.Api.Services.Mapper
{
    using System.Collections.Generic;

    using Microsoft.Extensions.DependencyInjection;

    using Weather.Api.V1.Models;
    using Weather.Api.V1.Models.OpenWeatherMap;
    using Weather.Data.Entities;

    public static class Configuration
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            return services
                .AddTransient<IMapper<OpenWeatherMap, List<WeatherModel>>, OpenWeatherMapper>()
                .AddTransient<IMapper<Information, HistoryModel>, HistoryMapper>();
        }
    }
}
