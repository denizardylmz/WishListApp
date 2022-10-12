using Application.Common.Exceptions;
using FluentValidation;
using MediatR;
using NuGet.Packaging.Signing;
using ValidationException = Application.Common.Exceptions.ValidationException;

namespace Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse > where TRequest : notnull, IRequest<TResponse>
{
    private IEnumerable<IValidator<TRequest>> _validators;


    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.
                Select(x => x.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .Where(x => x.Errors.Any())
                .SelectMany(x => x.Errors).ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}