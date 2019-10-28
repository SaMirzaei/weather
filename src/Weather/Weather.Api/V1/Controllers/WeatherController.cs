namespace Weather.Api.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Weather.Api.Services.Abstracts;

    public class WeatherController : ControllerBaseV1
    {
        private readonly IRestClientProxy _restClientProxy;

        public WeatherController(IRestClientProxy restClientProxy)
        {
            _restClientProxy = restClientProxy;
        }

        [HttpGet("forecast")]
        public IActionResult GetCity([FromQuery]Parameter parameter)
        {
            return Ok();
        }

        public class Parameter
        {
            public string City { get; set; }

            public string ZipCode { get; set; }
        }
    }
}
