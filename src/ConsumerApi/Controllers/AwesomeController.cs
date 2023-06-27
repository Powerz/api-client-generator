using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using WeatherApiClient;
using ValidationProblemDetails = Microsoft.AspNetCore.Mvc.ValidationProblemDetails;

namespace ConsumerApi.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class AwesomeController : ControllerBase
{
    private readonly IBillingApi _billingApi;
    private readonly IWeatherApi _weatherApi;

    public AwesomeController(IBillingApi billingApi, IWeatherApi weatherApi)
    {
        _billingApi = billingApi;
        _weatherApi = weatherApi;
    }

    [HttpGet("weather")]
    public Task<ICollection<WeatherForecast>> GetWeek()
    {
        return _weatherApi.GetWeekAsync();
    }

    [HttpPost("donate")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public Task<Greeting> Donate([FromBody]Payment payment)
    {
        return _billingApi.DonateAsync(payment);
    }
}