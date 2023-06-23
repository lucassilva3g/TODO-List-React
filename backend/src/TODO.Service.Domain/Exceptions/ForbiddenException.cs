namespace Todo.Service.Domain.Exceptions;

public class ForbiddenException : Exception
{
    public bool IsDefaultMessage { get; private set; }

    public ForbiddenException() : base()
    {
        IsDefaultMessage = true;
    }

    public ForbiddenException(string message) : base(message) { }
}
