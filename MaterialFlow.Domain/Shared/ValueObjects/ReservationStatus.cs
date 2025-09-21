namespace MaterialFlow.Domain.Shared.ValueObjects;

public sealed class ReservationStatus : SmartEnumeration<ReservationStatus>
{
    public static readonly ReservationStatus Reserved = new(nameof(Reserved), 1);
    public static readonly ReservationStatus Consumed = new(nameof(Consumed), 2);
    public static readonly ReservationStatus Cancelled = new(nameof(Cancelled), 3);

    private ReservationStatus(
        string name,
        int value) : base(name, value) { }
}
