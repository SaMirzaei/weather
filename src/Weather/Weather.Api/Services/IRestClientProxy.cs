namespace Weather.Api.Services
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    using RestSharp;

    using Weather.Api.Services.Abstracts;

    internal class RestClientProxy : IRestClientProxy
    {
        private readonly IRestRequestFactory _restRequestFactory;

        private readonly IRestClient _restClient;

        private readonly ILogger<RestClientProxy> _logger;

        private IRestRequest _request;

        public RestClientProxy(
            IRestRequestFactory restRequestFactory,
            IRestClient restClient,
            ILogger<RestClientProxy> logger)
        {
            _restRequestFactory = restRequestFactory;
            _restClient = restClient;
            _logger = logger;
        }

        public IRestClientProxy Setup(Action<IRestRequest> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _request = _restRequestFactory.Create();

            action(_request);

            return this;
        }

        public IActionResult Execute()
        {
            switch (_request)
            {
                case null:
                    throw new InvalidOperationException("Request hasn't been setup");

                case RestRequestFactory.UnauthorizedRequest _:
                    return new StatusCodeResult(401);
            }

            var response = _restClient.Execute(_request);

            if (response.IsSuccessful)
            {
                return new ContentResult
                {
                    ContentType = _restRequestFactory.ContentType,
                    Content = response.Content,
                    StatusCode = (int)response.StatusCode
                };
            }

            var statusCode = response.StatusCode;
            var content = response.Content;

            _logger.LogError("Proxy call failed: [{statusCode}] {response.Content}", statusCode, content);

            return new StatusCodeResult((int)response.StatusCode);
        }

        public async Task<IActionResult> ExecuteAsync()
        {
            switch (_request)
            {
                case null:
                    throw new InvalidOperationException("Request hasn't been setup.");

                case RestRequestFactory.UnauthorizedRequest _:
                    return new StatusCodeResult(401);
            }

            var cancellationTokenSource = new CancellationTokenSource();
            var response = await _restClient.ExecuteTaskAsync(_request, cancellationTokenSource.Token);

            if (response.IsSuccessful)
            {
                return new ContentResult
                {
                    ContentType = _restRequestFactory.ContentType,
                    Content = response.Content,
                    StatusCode = (int)response.StatusCode
                };
            }

            var statusCode = response.StatusCode;
            var content = response.Content;

            _logger.LogError("Proxy call failed: [{statusCode}] {response.Content}", statusCode, content);

            return new StatusCodeResult((int)response.StatusCode);
        }

        public ActionResult<T> Execute<T>()
        {
            var result = Execute();

            if (!(result is ContentResult))
            {
                return result as StatusCodeResult;
            }

            var content = result as ContentResult;

            return JsonConvert.DeserializeObject<T>(content.Content);
        }

        public async Task<ActionResult<T>> ExecuteAsync<T>()
        {
            var result = await ExecuteAsync();

            if (!(result is ContentResult))
            {
                return result as StatusCodeResult;
            }

            var content = result as ContentResult;

            return JsonConvert.DeserializeObject<T>(content.Content);
        }
    }
}
