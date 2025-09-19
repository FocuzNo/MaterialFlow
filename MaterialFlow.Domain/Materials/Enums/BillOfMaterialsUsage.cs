namespace MaterialFlow.Domain.Materials.Enums;

public sealed class BillOfMaterialsUsage : SmartEnumeration<BillOfMaterialsUsage>
{
    public static readonly BillOfMaterialsUsage Production = new(nameof(Production), 1);
    public static readonly BillOfMaterialsUsage Sales = new(nameof(Sales), 2);

    private BillOfMaterialsUsage(
        string name,
        int value) : base(name, value) { }
}