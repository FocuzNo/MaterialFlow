namespace MaterialFlow.Domain.Abstractions;

public record Error(
    string Code,
    string Name)
{
    public static readonly Error None = new(
        string.Empty,
        string.Empty);

    public static readonly Error NullValue = new(
        $"{nameof(Error)}.{NullValue}",
        "Null value was provided");
}
