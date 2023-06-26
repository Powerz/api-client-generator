namespace WebApi.Weather;

public record WeatherForecast
{
    public required DateOnly Date { get; init; }
    public required int TemperatureC { get; init; }

    public string Summary => TemperatureC switch
    {
        <= -40 => "Freezing",
        <= -30 => "Bracing",
        <= -20 => "Chilly",
        <= 0   => "Cool",
        <= 10  => "Mild",
        <= 20  => "Warm",
        <= 30  => "Balmy",
        <= 40  => "Sydney",
        _      => "Brisbane"
    };
}