namespace Weather.Api.Services
{
    using Microsoft.Extensions.Options;

    using RestSharp;

    using Weather.Api.Services.Abstracts;

    internal class RestClientFactory : IRestClientFactory
    {
        private readonly AppOptions _appOptions;

        public RestClientFactory(IOptions<AppOptions> appOptions)
        {
            _appOptions = appOptions.Value;
        }

        public IRestClient Create()
        {
            return new RestClient(_appOptions.ApiUrl);
        }
    }
}
