namespace TODO.Service.Persistence;

public class TODOInitializer
{
    public static void Initialize(CredMouraContext context)
    {
        var instance = new TODOInitializer();
        instance.Seed(context);
    }

    private void Seed(CredMouraContext context)
    {
        SeedDatabase(context);
    }

    private void SeedDatabase(CredMouraContext context)
    {
        // TODO: Seed database
    }
}
