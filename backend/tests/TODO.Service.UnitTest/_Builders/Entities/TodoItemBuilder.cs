namespace Todo.Service.UnitTest._Builders.Entities;

public class TodoItemBuilder : BaseComplexDbEntityBuilder<TodoItemBuilder, TodoItem>
{
    private bool Active;
    private bool IsDone;


    public static new TodoItemBuilder New()
    {
        return new TodoItemBuilder()
        {
            Active = true,
            IsDone = false
        };
    }

    protected override TodoItemBuilder GetThis()
    {
        return this;
    }

    public override TodoItem Build()
    {
        var model = new TodoItem()
        {
            Active = Active,
            IsDone = IsDone,
        };

        return base.Build(model);
    }
}
