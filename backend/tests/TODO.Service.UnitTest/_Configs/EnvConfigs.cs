namespace Todo.Service.UnitTest._Configs;

public static class EnvConfigs
{
    public static void ConfigureRequiredEnvs()
    {
        Environment.SetEnvironmentVariable(EnvConstants.ENV_DATABASE_CONNECTION_STRING, "faker_conn");
    }

    public static void SetEnvValue(string envName, string value)
    {
        Environment.SetEnvironmentVariable(envName, value);
    }
}
