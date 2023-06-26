using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Billing;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class BillingController : ControllerBase
{
    [HttpPost("donate")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public ActionResult<Greeting> Donate(Payment payment)
    {
        return new Greeting();
    }
}