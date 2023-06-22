using TODO.Service.Api.Filters;

namespace TODO.Service.Api.Helpers;

public static class FiltersHelper
{
    public static void AddCustomFilters(this MvcOptions options)
    {
        options.Filters.Add(typeof(CustomExceptionFilter));
        options.Filters.Add(typeof(ActionLogFilter));
    }
}
