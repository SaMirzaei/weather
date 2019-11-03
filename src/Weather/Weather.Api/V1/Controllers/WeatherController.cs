namespace Weather.Api.V1.Controllers
{
    using System.Threading;
    using System.Threading.Tasks;

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
        public async Task<IActionResult> GetCity([FromQuery]SearchKey searchKey, CancellationToken cancellationToken)
        {
            if (searchKey == null)
            {
                return BadRequest();
            }

            var result = !string.IsNullOrEmpty(searchKey.City) ?
                            await _weatherService.GetByCity(searchKey.City, cancellationToken) :
                            await _weatherService.GetByZipCide(searchKey.ZipCode, cancellationToken);

            return Ok(result);
        }

        [HttpGet("history/{city}")]
        public async Task<IActionResult> History(string city, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest();
            }

            var result = await _weatherService.GetHistory(city, cancellationToken);
            
            return Ok(result);
        }
    }
}
