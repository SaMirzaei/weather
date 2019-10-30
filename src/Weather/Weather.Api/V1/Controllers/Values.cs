namespace Weather.Api.V1.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using RestSharp;

    using Weather.Api.Services.Abstracts;
    using Weather.Api.V1.Models;
    using Weather.Data.Entities;

    public class Values : ControllerBaseV1
    {
        private readonly IRestClientProxy _restClientProxy;

        private readonly ApiContext _context;

        public Values(
            IRestClientProxy restClientProxy,
            ApiContext context)
        {
            _restClientProxy = restClientProxy;
            _context = context;
        }

        [HttpGet]
        public string Get()
        {
            var result = _context.Informations.ToList();

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
