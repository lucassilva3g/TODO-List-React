using Todo.Service.Api.Filters;

namespace Todo.Service.Api.Helpers;

public static class FiltersHelper
{
    public static void AddCustomFilters(this MvcOptions options)
    {
        options.Filters.Add(typeof(CustomExceptionFilter));
        options.Filters.Add(typeof(ActionLogFilter));
    }
}
