namespace Todo.Service.Domain.Entities.General;

public abstract class SimpleDbEntity : DbEntity
{
    public int Id { get; set; }
}
