namespace MovieManager.Application.Common.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;
    private readonly Stopwatch _timer;

    public PerformanceBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
        _timer = new Stopwatch();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();
        var response = await next();
        _timer.Stop();

        var requestName = typeof(TRequest).Name;

        var elapsedTime = _timer.ElapsedMilliseconds;
        _logger.LogInformation($"[CUSTOM LOGGING] Query handling time for request {requestName} was: {elapsedTime} ms");

        return response;
    }
}