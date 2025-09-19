namespace MaterialFlow.Domain.Abstractions;

public abstract class SmartEnumeration<TEnum> where TEnum : SmartEnumeration<TEnum>
{
    public string Name { get; }

    public int Value { get; }

    protected SmartEnumeration(
        string name,
        int value)
    {
        Name = name;
        Value = value;
    }

    public static IReadOnlyCollection<TEnum> GetAll() =>
        typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => (TEnum)f.GetValue(null)!).ToArray();

    public static TEnum FromName(string name) =>
        GetAll().Single(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));

    public static TEnum FromValue(int value) =>
        GetAll().Single(x => x.Value == value);
}