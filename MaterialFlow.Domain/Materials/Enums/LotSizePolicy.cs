namespace MaterialFlow.Domain.Materials.Enums;

public sealed class LotSizePolicy : SmartEnumeration<LotSizePolicy>
{
    public static readonly LotSizePolicy FixedLot = new(nameof(FixedLot), 1);
    public static readonly LotSizePolicy LotForLot = new(nameof(LotForLot), 2);
    public static readonly LotSizePolicy Weekly = new(nameof(Weekly), 3);

    private LotSizePolicy(
        string name,
        int value) : base(name, value) { }
}