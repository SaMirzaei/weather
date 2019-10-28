namespace Weather.Api.Services
{
    using System;

    using Microsoft.Extensions.Logging;

    using RestSharp;

    using Weather.Api.Services.Abstracts;

    internal class RestRequestFactory : IRestRequestFactory
    {
        private readonly ILogger<RestRequestFactory> _logger;

        public RestRequestFactory(
            ILogger<RestRequestFactory> logger)
        {
            _logger = logger;
            ContentType = "application/json";
        }

        public string ContentType { get; set; }

        public IRestRequest Create()
        {
            try
            {
                var result = new RestRequest();

                result.AddHeader("Content-Type", ContentType);

                // TODO: Adding Authorization

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
