namespace Weather.Api.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Weather.Api.Services.Abstracts;
    using Weather.Api.V1.Models;

    public class WeatherController : ControllerBaseV1
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("forecast")]
        public IActionResult GetCity([FromQuery]SearchKey searchKey)
        {
            if (searchKey == null)
            {
                return BadRequest();
            }

            var result = !string.IsNullOrEmpty(searchKey.City) ?
                            _weatherService.GetByCity(searchKey.City) :
                            _weatherService.GetByZipCide(searchKey.ZipCode);

            return Ok(result);
        }

        [HttpGet("history/{city}")]
        public IActionResult History(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest();
            }

            var result = _weatherService.GetHistory(city);
            
            return Ok(result);
        }
    }
}
