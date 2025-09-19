namespace MaterialFlow.Domain.Materials.Enums;

public sealed class RecommendedActionCode : SmartEnumeration<RecommendedActionCode>
{
    public static readonly RecommendedActionCode Create = new(nameof(Create), 1);
    public static readonly RecommendedActionCode Expedite = new(nameof(Expedite), 2);
    public static readonly RecommendedActionCode Postpone = new(nameof(Postpone), 3);

    private RecommendedActionCode(
        string name,
        int value) : base(name, value) { }
}