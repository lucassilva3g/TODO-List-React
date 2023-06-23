namespace Todo.Service.Domain.Entities;

public class TodoItem: ETracker
{
    public string Title { get; set; }

    public string Description { get; set; }

    public bool IsDone { get; set; }

    public DateTime? DueDate { get; set; }

    public bool Active { get; set; }
}