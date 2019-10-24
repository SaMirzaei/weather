namespace Weather.Api.V1.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class Values : ControllerBaseV1
    {
        public Values()
        {
        }

        [HttpGet]
        public string Get()
        {
            return "Pong at...";
        }
    }
}
