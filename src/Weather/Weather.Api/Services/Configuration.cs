namespace Weather.Api.Services
{
    using Microsoft.Extensions.DependencyInjection;

    using Weather.Api.Services.Abstracts;

    public static class Configuration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            return services.AddTransient<IWeatherService, WeatherService>();
        }
    }
}
