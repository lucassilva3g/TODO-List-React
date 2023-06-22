
using TODO.Service.Domain.Utils;

namespace TODO.Service.Api.Middlewares;

public class LoggerScopeMiddleware
{
    private readonly RequestDelegate _next;

    public LoggerScopeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string sessionId = Guid.NewGuid().ToString();

        var logger = context.RequestServices.GetRequiredService<ILogger<LoggerScopeMiddleware>>();

        using (logger.BeginScope(new[] { new KeyValuePair<string, object>(Constants.LOG_GROUP_ID_NAME, sessionId) }))
        {
            logger.LogInformation("Begin Request [{@Path}] with method [{@Method}]", context.Request.Path, context.Request.Method);

            await _next(context);

            logger.LogInformation("End Request [{@Path}] with status code [{@Method}]", context.Request.Path, context.Response.StatusCode);
        }
    }
}
