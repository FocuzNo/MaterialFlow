namespace MaterialFlow.Domain.Shared.ValueObjects;

public sealed record Quantity(
    decimal Amount,
    UnitOfMeasure UnitOfMeasure)
{
    public Quantity AddAssumingSameUom(Quantity other) =>
        new(Amount + other.Amount, UnitOfMeasure);
}