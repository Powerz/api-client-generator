using Bogus;

namespace WeatherApi.Weather;

public class FortuneTeller
{
    private readonly Faker<WeatherForecast> _faker;
    private int _counter;

    public FortuneTeller()
    {
        _faker = new Faker<WeatherForecast>()
            .RuleFor(x => x.Date, () => DateOnly.FromDateTime(DateTimeOffset.UtcNow.AddDays(_counter++).Date))
            .RuleFor(x => x.TemperatureC, x => x.Random.Int(-50, 50));
    }

    public IEnumerable<WeatherForecast> WeeklyForecast()
    {
        return _faker.Generate(7);
    }
}