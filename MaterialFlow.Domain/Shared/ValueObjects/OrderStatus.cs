namespace MaterialFlow.Domain.Shared.ValueObjects;

public sealed class OrderStatus : SmartEnumeration<OrderStatus>
{
    public static readonly OrderStatus Created = new(nameof(Created), 1);
    public static readonly OrderStatus Open = new(nameof(Open), 2);
    public static readonly OrderStatus Closed = new(nameof(Closed), 3);
    public static readonly OrderStatus Cancelled = new(nameof(Cancelled), 4);

    private OrderStatus()
        : base(string.Empty, 0) { }

    private OrderStatus(string name, int value)
        : base(name, value) { }
}
