using MediatR;
using TODO.Service.Application.Services.Interfaces;
using TODO.Service.Application.Settings;
using TODO.Service.Domain.Resources;

namespace TODO.Service.CrossCutting;

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
