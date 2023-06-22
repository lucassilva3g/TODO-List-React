using TODO.Service.Application.Integrations;

namespace TODO.Service.CrossCutting;

public static class ConfigureMapster
{
    public static IServiceCollection InjectMapster(this IServiceCollection services)
    {
        MappingConfig mappingConfig = new MappingConfig();

        services.AddSingleton(mappingConfig);

        return services;
    }
}