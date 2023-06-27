using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Weather;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class WeatherController : ControllerBase
{
    private readonly FortuneTeller _fortuneTeller = new();

    [HttpGet("week")]
    public IEnumerable<WeatherForecast> GetWeek()
    {
        return _fortuneTeller.WeeklyForecast();
    }
}