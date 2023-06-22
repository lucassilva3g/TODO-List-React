using TODO.Service.Api.Middlewares;

namespace TODO.Service.Api.Helpers;

public static class MiddlewaresHelper
{
    public static IApplicationBuilder UseLoggerScope(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoggerScopeMiddleware>();
    }
}
