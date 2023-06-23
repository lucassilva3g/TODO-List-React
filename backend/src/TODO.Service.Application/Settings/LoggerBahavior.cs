using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Service.Application.Settings;

public class LoggerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<LoggerBehavior<TRequest, TResponse>> _logger;

    public LoggerBehavior(ILogger<LoggerBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest);
        var responseName = typeof(TResponse);

        var watch = Stopwatch.StartNew();

        _logger.LogDebug("Handling Request [{@requestName}] with payload: {@request}", requestName, request);

        try
        {
            var response = await next();

            _logger.LogDebug("Handled Request [{@requestName}] with Response [{@responseName}]", requestName, responseName);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {@requestName}", requestName);

            throw;
        }
        finally
        {
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            _logger.LogInformation("Request [{@requestName}] elapsed {@elapsedMs}ms", requestName, elapsedMs);
        }
    }
}
