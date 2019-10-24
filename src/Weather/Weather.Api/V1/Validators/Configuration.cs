namespace Weather.Api.V1.Validators
{
    using Microsoft.Extensions.DependencyInjection;

    public static class Configuration
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            return services;
        }
    }
}
