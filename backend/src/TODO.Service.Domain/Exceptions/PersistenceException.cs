namespace TODO.Service.Domain.Exceptions;

public class PersistenceException : Exception
{
    public PersistenceException(Exception exception) : base(exception.Message, exception) { }
}
