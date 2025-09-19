namespace MaterialFlow.Domain.Materials.Enums;

public sealed class ProcurementType : SmartEnumeration<ProcurementType>
{
    public static readonly ProcurementType InHouse = new(nameof(InHouse), 1);
    public static readonly ProcurementType External = new(nameof(External), 2);
    public static readonly ProcurementType Mixed = new(nameof(Mixed), 3);

    private ProcurementType(
        string name,
        int value) : base(name, value) { }
}