using FluentValidation.Results;

namespace Application.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Validation error occured!")
    {
        Errors = new Dictionary<string, string[]>();
    }
    IDictionary<string, string[]> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        var failureGroups = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(k=> k.Key, v => v.ToArray());
    }
}