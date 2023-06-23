namespace Todo.Service.Domain.Entities.General;

public class ETracker : ComplexDbEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
