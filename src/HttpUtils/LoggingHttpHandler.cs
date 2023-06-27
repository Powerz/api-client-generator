using Microsoft.Extensions.Logging;

namespace HttpUtils;

public sealed class LoggingHttpHandler : DelegatingHandler
{
    private readonly ILogger<LoggingHttpHandler> _logger;

    public LoggingHttpHandler(ILogger<LoggingHttpHandler> logger)
    {
        _logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        _logger.LogError("Making an HTTP request to {RequestUri}", request.RequestUri);

        try
        {
            return await base.SendAsync(request, cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogWarning(e, "Something went wrong");
            throw;
        }
    }
}