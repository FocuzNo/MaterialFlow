namespace MaterialFlow.Domain.Materials.ValueObjects;

public sealed record Quantity(
    decimal Amount,
    UnitOfMeasure UnitOfMeasure)
{
    public Quantity Add(Quantity other) =>
        other.UnitOfMeasure == UnitOfMeasure
            ? new(Amount + other.Amount, UnitOfMeasure)
            : throw new InvalidOperationException("Unit of measure mismatch.");
}