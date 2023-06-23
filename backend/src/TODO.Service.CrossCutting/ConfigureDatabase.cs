using Microsoft.EntityFrameworkCore;
using Todo.Service.Domain.Settings;
using Todo.Service.Persistence;

namespace Todo.Service.CrossCutting;
public static class ConfigureDatabase
{
    public static IServiceCollection InjectDatabases(this IServiceCollection services)
    {
        var connString = EnvConstants.DATABASE_CONNECTION_STRING();

        services.AddDbContext<TodoContext>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseNpgsql(connString);
        });

        services.AddScoped<ITodoContext>(provider => provider.GetService<TodoContext>());

        return services;
    }
}
