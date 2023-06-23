using Microsoft.AspNetCore.Mvc.Filters;

namespace Todo.Service.Api.Filters;

public class ActionLogFilter : IActionFilter
{
    private readonly ILogger<ActionLogFilter> _logger;

    public ActionLogFilter(ILogger<ActionLogFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogDebug("Calling {@ActionName}", context.ActionDescriptor.DisplayName);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogDebug("Called {@ActionName}", context.ActionDescriptor.DisplayName);
    }
}
