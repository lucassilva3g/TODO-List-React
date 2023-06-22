using Microsoft.EntityFrameworkCore;
using TODO.Service.Domain.Settings;
using TODO.Service.Persistence;

namespace TODO.Service.CrossCutting;
public static class ConfigureDatabase
{
    public static IServiceCollection InjectDatabases(this IServiceCollection services)
    {
        var connString = EnvConstants.DATABASE_CONNECTION_STRING();

        services.AddDbContext<CredMouraContext>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseNpgsql(connString);
        });

        services.AddScoped<ICredMouraContext>(provider => provider.GetService<CredMouraContext>());

        return services;
    }
}
