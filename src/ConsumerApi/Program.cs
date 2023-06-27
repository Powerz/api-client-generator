using HttpUtils;
using WeatherApiClient;

var builder = WebApplication.CreateBuilder(args);

var weatherApiUri = new Uri(builder.Configuration["WeatherApiUrl"]!);

builder.Services
    .AddTransient<LoggingHttpHandler>();

builder.Services
    .AddHttpClient<IBillingApi, BillingApi>(x => x.BaseAddress = weatherApiUri)
    .AddHttpMessageHandler<LoggingHttpHandler>();
    // .AddHttpMessageHandler<CorrelationIdHandler>()
    // .AddHttpMessageHandler<ErrorsHandler>()
    // .AddHttpMessageHandler<ApiTokenHandler>()
    // .AddHttpMessageHandler<SomeOtherAwesomeHandlerHandler>();

builder.Services
    .AddHttpClient<IWeatherApi, WeatherApi>(x => x.BaseAddress = weatherApiUri)
    .AddHttpMessageHandler<LoggingHttpHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();