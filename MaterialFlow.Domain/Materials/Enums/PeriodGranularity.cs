namespace MaterialFlow.Domain.Materials.Enums;

public sealed class PeriodGranularity : SmartEnumeration<PeriodGranularity>
{
    public static readonly PeriodGranularity Day = new(nameof(Day), 1);
    public static readonly PeriodGranularity Week = new(nameof(Week), 2);
    public static readonly PeriodGranularity Month = new(nameof(Month), 3);

    private PeriodGranularity(
        string name,
        int value) : base(name, value) { }
}