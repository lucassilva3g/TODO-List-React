namespace Todo.Service.CrossCutting;

public static class ConfigureLocalization
{
    public static IServiceCollection InjectLocalization(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");

        return services;
    }
}
