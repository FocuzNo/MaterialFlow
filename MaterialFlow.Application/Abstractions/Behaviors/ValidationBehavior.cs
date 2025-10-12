using MaterialFlow.Application.Abstractions.Messaging;
using MaterialFlow.Application.Exceptions;

namespace MaterialFlow.Application.Abstractions.Behaviors;

internal sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next(cancellationToken);
        }

        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        if (failures.Any())
        {
            var errorsDictionary = failures
                .GroupBy(f => f.PropertyName ?? string.Empty)
                .ToDictionary(
                    g => g.Key,
                    g => g
                    .Select(f => f.ErrorMessage)
                    .Where(m => !string.IsNullOrWhiteSpace(m))
                    .Distinct()
                    .ToArray()
                );

            var validationError = new ValidationError(
                code: "Validation.Error",
                description: "One or more validation errors occurred.",
                errors: errorsDictionary);

            throw new Exceptions.ValidationException([validationError]);
        }

        return await next(cancellationToken);
    }
}
