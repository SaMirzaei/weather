namespace Weather.Tests.Web.Controllers
{
    using System.Threading;

    using FluentAssertions;

    using Microsoft.AspNetCore.Mvc;

    using NSubstitute;

    using Weather.Api.Services.Abstracts;
    using Weather.Api.V1.Controllers;
    using Weather.Api.V1.Models;

    using Xunit;

    public class WeatherControllerTests
    {
        private readonly WeatherController _weatherContrller;

        public WeatherControllerTests()
        {
            var weatherService = Substitute.For<IWeatherService>();

            _weatherContrller = new WeatherController(weatherService);
        }

        [Fact]
        public void WhenModelIsNullThenBarRequestReturned()
        {
            _weatherContrller
                .GetCity(null, CancellationToken.None)
                .Result
                .Should()
                .BeOfType<BadRequestResult>();
        }

        [Fact]
        public void WhenFetchDataThenOkReturned()
        {
            var searchKey = new SearchKey
            {
                City = "Leipzig"
            };

            _weatherContrller
                .GetCity(searchKey, CancellationToken.None)
                .Result
                .Should()
                .BeOfType<OkObjectResult>();
        }
    }
}