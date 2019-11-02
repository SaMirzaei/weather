namespace Weather.Api.Infrastructures
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    using RestSharp;

    using Weather.Api.Infrastructures.Abstracts;

    internal class RestRequestFactory : IRestRequestFactory
    {
        private readonly ILogger<RestRequestFactory> _logger;

        private readonly AppOptions _options;

        public RestRequestFactory(
            ILogger<RestRequestFactory> logger,
            IOptions<AppOptions> options)
        {
            _logger = logger;
            _options = options.Value;
            ContentType = "application/json";
        }

        public string ContentType { get; set; }

        public IRestRequest Create()
        {
            try
            {
                var result = new RestRequest();

                result.AddHeader("Content-Type", ContentType);

                result.Parameters.Add(new Parameter("APPID", _options.AppId, ParameterType.QueryString));
                result.Parameters.Add(new Parameter("mode", "json", ParameterType.QueryString));

                return result;
            }
            catch (UnauthorizedRequestException)
            {
                _logger.LogError("Unauthorized request is detected.");
                return new UnauthorizedRequest();
            }
        }

        public class UnauthorizedRequest : RestRequest
        {
        }
    }
}
