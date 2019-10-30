namespace Weather.Api.V1.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Mvc;

    using Weather.Api.Services.Abstracts;
    using Weather.Api.V1.Models;

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
            var result = new List<WeatherModel>
            {
                new WeatherModel { Coutnry = "IR", City = "Tehran", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "IR", City = "Tehran", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "IR", City = "Tehran", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "IR", City = "Tehran", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "IR", City = "Tehran", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
                new WeatherModel { Coutnry = "IR", City = "Tehran", Humidity = 120, MaxTemperature = 160.127, MinTemperature = 150.54, Wind = 200},
            };

            return Ok(result);
        }

        public class Parameter
        {
            public string City { get; set; }

            public string ZipCode { get; set; }
        }
    }
}
