using Todo.Service.Domain.Entities.General;

namespace Todo.Service.UnitTest._Builders;

public abstract class BaseComplexDbEntityBuilder<TBuilder, TConcrete>
        where TBuilder : new()
        where TConcrete : ComplexDbEntity
{
    protected Guid id;

    public static TBuilder New()
    {
        return new TBuilder();
    }

    public TBuilder WithId(Guid value)
    {
        id = value;

        return GetThis();
    }

    protected abstract TBuilder GetThis();

    public abstract TConcrete Build();

    protected TConcrete Build(TConcrete model)
    {
        if (model is null)
            return model;

        model.Id = id;

        return model;
    }
}
