namespace Todo.Service.Domain.Exceptions;

public class BusinessException : Exception
{
    public BusinessException(string message)
        : base(message)
    { }
}
