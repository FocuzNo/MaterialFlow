namespace MaterialFlow.Application.Exceptions;

public sealed record ValidationError : Error
{
    public ValidationError(
        string code,
        string description,
        IReadOnlyDictionary<string, string[]> errors)
        : base(code, description, ErrorType.Validation) => Errors = errors;

    public IReadOnlyDictionary<string, string[]> Errors { get; }
}