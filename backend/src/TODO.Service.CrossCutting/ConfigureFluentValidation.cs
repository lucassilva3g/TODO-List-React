namespace Todo.Service.CrossCutting;

public static class ConfigureFluentValidation
{
    public static IServiceCollection InjectFluentValidation(this IServiceCollection services)
    {
        //services.AddValidatorsFromAssemblyContaining<YourValidator>();

        return services;
    }
}
