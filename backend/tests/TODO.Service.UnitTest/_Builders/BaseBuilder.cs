namespace Todo.Service.UnitTest._Builders;

public abstract class BaseBuilder<TBuilder, TConcrete>
        where TBuilder : new()
{
    public static TBuilder New()
    {
        return new TBuilder();
    }

    public abstract TConcrete Build();
}

