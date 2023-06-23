namespace Todo.Service.Domain.Exceptions;

public class AuthorizationException : Exception
{
    public bool IsDefaultMessage { get; private set; }

    public AuthorizationException() : base()
    {
        IsDefaultMessage = true;
    }

    public AuthorizationException(string message) : base(message) { }
}
