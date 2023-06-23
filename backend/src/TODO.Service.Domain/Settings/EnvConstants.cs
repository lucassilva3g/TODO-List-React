using System.Reflection;
using System.Runtime.CompilerServices;
using Todo.Service.Domain.Exceptions;

[assembly: InternalsVisibleTo("Todo.Service.UnitTest")]
namespace Todo.Service.Domain.Settings;

public static class EnvConstants
{
    internal const string ENV_DATABASE_CONNECTION_STRING = "DATABASE_CONNECTION_STRING";

    private static BusinessException InvalidValue(string envName) => new($"Invalid value for env var {envName}");

    private static string GetEnvironmentVariable(string name)
    {
        return Environment.GetEnvironmentVariable(name);
    }

    private static string GetEnvironmentVariable(string name, string defaultValue, bool errorIfEmpty = false)
    {
        var value = GetEnvironmentVariable(name);

        if (string.IsNullOrWhiteSpace(value))
        {
            if (errorIfEmpty)
            {
                throw new Exception($"Env var {name} must contain value.");
            }
            return defaultValue;
        }

        return value;
    }

    private static string GetRequiredEnvironmentVariable(string name)
    {
        return GetEnvironmentVariable(name, null, true) ?? string.Empty;
    }

    public static string DATABASE_CONNECTION_STRING() => GetRequiredEnvironmentVariable(ENV_DATABASE_CONNECTION_STRING);

    public static void ValidateRequiredEnvs()
    {
        var methodInfos = typeof(EnvConstants)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(e => e.ReturnType != typeof(void))
            .Where(e => !e.GetParameters().Any())
            .ToList();

        var errors = new List<string>();

        foreach (var item in methodInfos)
        {
            try
            {
                item.Invoke(null, null);
            }
            catch (Exception ex)
            {
                errors.Add(ex.InnerException?.Message ?? ex.Message);
            }
        }

        if (errors.Count > 0) throw new Exception(string.Join("\n", errors));
    }
}
