namespace MaterialFlow.Domain.Materials.Enums;

public sealed class MaterialRequirementsPlanningType : SmartEnumeration<MaterialRequirementsPlanningType>
{
    public static readonly MaterialRequirementsPlanningType ClassicMrp = new(nameof(ClassicMrp), 1);
    public static readonly MaterialRequirementsPlanningType ConsumptionBased = new(nameof(ConsumptionBased), 2);

    private MaterialRequirementsPlanningType(
        string name,
        int value) : base(name, value) { }
}