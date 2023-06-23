namespace Todo.Service.Application.Models.ViewModels;

public class CreateSuccess
{
    public CreateSuccess(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
