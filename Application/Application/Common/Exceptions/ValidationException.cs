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
        var failureGroups = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage);

        foreach (var failureGroup in failureGroups)
        {
            var property = failureGroup.Key;
            var errorMessages = failureGroup.ToArray();
            Errors.Add(property, errorMessages);
        }
    }
}