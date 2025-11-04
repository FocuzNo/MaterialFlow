namespace MaterialFlow.Domain.Shared.ValueObjects;

public sealed class Quantity
{
    private Quantity() { }

    public Quantity(
        decimal amount,
        UnitOfMeasure unitOfMeasure)
    {
        Amount = amount;
        UnitOfMeasure = unitOfMeasure;
    }

    public decimal Amount { get; private set; }

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public Quantity AddAssumingSameUom(Quantity other) =>
        new(Amount + other.Amount, UnitOfMeasure);
}