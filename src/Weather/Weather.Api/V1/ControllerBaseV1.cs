namespace Weather.Api.V1
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public abstract class ControllerBaseV1 : MainController
    {
    }
}
