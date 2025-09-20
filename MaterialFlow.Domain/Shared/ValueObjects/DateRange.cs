namespace MaterialFlow.Domain.Shared.ValueObjects;

public sealed record DateRange(
    DateOnly StartDate,
    DateOnly EndDate)
{
    public bool Contains(DateOnly date) =>
        date >= StartDate && date <= EndDate;
}