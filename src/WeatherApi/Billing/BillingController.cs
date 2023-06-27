using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Billing;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class BillingController : ControllerBase
{
    [HttpPost("donate")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Greeting))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public ActionResult<Greeting> Donate([FromBody]Payment payment)
    {
        return new Greeting();
    }
}