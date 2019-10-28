namespace Weather.Api.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RestSharp;

    using Weather.Api.Services.Abstracts;
    using Weather.Api.V1.Models;

    public class Values : ControllerBaseV1
    {
        private readonly IRestClientProxy _restClientProxy;

        public Values(IRestClientProxy restClientProxy)
        {
            _restClientProxy = restClientProxy;
        }

        [HttpGet]
        public string Get()
        {
            var data = _restClientProxy
                .Setup(
                    t =>
                        {
                            t.Resource = string.Empty;
                            t.Parameters.Add(new Parameter("q", "London,us", ParameterType.QueryString));
                            t.Parameters.Add(new Parameter("mode", "json", ParameterType.QueryString));
                            t.Parameters.Add(new Parameter("APPID", "fcadd28326c90c3262054e0e6ca599cd", ParameterType.QueryString));
                        })
                .Execute<OpenWeatherMap>();

            return "Pong at...";
        }
    }
}
