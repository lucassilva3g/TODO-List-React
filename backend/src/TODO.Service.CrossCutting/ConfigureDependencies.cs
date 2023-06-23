using MediatR;
using Todo.Service.Application.Services.Interfaces;
using Todo.Service.Application.Settings;
using Todo.Service.Domain.Resources;

namespace Todo.Service.CrossCutting;

public static class ConfigureDependencies
{
    public static IServiceCollection InjectDependencies(this IServiceCollection services)
    {
        services.InjectApplicationDependencies();

        return services;
    }

    private static IServiceCollection InjectApplicationDependencies(this IServiceCollection services)
    {
        services.AddSingleton<Messages>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddScoped<IBaseValidationService, BaseValidationService>();

        return services;
    }
}
