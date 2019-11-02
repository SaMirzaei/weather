namespace Weather.Api.Infrastructures
{
    using Microsoft.Extensions.DependencyInjection;

    using Weather.Api.Infrastructures.Abstracts;

    public static class Configuration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IRestClientFactory, RestClientFactory>()
                .AddTransient<IRestRequestFactory, RestRequestFactory>()
                .AddTransient<IRestClientProxy, RestClientProxy>()
                .AddTransient(t => t.GetService<IRestClientFactory>().Create());
        }
    }
}
