using FluentValidation;

namespace Todo.Service.Application.Settings;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.ValidateAsync(context))
            .SelectMany(result => result.GetAwaiter().GetResult().Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Count != 0)
        {
            throw new Exceptions.FluentValidationException(failures);
        }

        return next();
    }
}
