using FluentValidation.Results;

namespace Todo.Service.Application.Settings.Exceptions;

public class FluentValidationException : Exception
{
    public FluentValidationException() : base()
    {
        Failures = new Dictionary<string, string[]>();
    }

    public FluentValidationException(List<ValidationFailure> failures) : this()
    {
        var propertyNames = failures
            .Select(e => e.PropertyName)
            .Distinct();

        foreach (var propertyName in propertyNames)
        {
            var propertyFailures = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            Failures.Add(propertyName.ToString(), propertyFailures);
        }
    }

    public Dictionary<string, string[]> Failures { get; }
}

