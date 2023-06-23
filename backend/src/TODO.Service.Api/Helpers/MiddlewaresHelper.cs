using Todo.Service.Api.Middlewares;

namespace Todo.Service.Api.Helpers;

public static class MiddlewaresHelper
{
    public static IApplicationBuilder UseLoggerScope(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggerScopeMiddleware>();
    }
}
