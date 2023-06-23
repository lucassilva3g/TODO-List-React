using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Service.Application.WeatherForecast.Queries.List;

[assembly: ExcludeFromCodeCoverage]
namespace Todo.Service.CrossCutting;

public static class ConfigureMediatR
{
    public static IServiceCollection InjectMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ListWeatherForecastsQuery>());

        return services;
    }
}
