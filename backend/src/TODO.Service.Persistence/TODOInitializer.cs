namespace Todo.Service.Persistence;

public class TodoInitializer
{
    public static void Initialize(TodoContext context)
    {
        var instance = new TodoInitializer();
        instance.Seed(context);
    }

    private void Seed(TodoContext context)
    {
        SeedTodoItem(context);
    }

    private void SeedTodoItem(TodoContext context)
    {
        if (context.TodoItems.Any()) return;

        var todoItem = new TodoItem
        {
            Id = Guid.NewGuid(),
            Title = "Default Todo Item",
            Description = "Default Todo Item Description",
            IsDone = false
        };

        context.TodoItems.Add(todoItem);

        context.SaveChanges();
    }
}
