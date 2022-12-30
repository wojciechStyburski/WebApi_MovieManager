namespace MovieManager.Application.Common.Behaviours;

public class LoggingBehaviour <TRequest> : IRequestPreProcessor<TRequest>
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        _logger.LogInformation($"[CUSTOM LOGGING] Request: {requestName}, content: {request}");
    }
}