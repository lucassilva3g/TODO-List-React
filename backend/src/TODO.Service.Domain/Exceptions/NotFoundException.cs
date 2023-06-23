namespace Todo.Service.Domain.Exceptions;

public class NotFoundException : Exception
{
    public string Name { get; private set; }
    public object Key { get; private set; }
    public bool IsDefaultMessage { get; private set; }

    public NotFoundException(string name, object key) : base()
    {
        Name = name;
        Key = key;
        IsDefaultMessage = true;
    }

    public NotFoundException(string message) : base(message)
    { }
}
