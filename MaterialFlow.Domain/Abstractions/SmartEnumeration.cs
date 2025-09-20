
namespace MaterialFlow.Domain.Abstractions;

public abstract class SmartEnumeration<TEnum>(
    string name,
    int value) where TEnum : SmartEnumeration<TEnum>
{
    public string Name { get; } = name;

    public int Value { get; } = value;

    private static IReadOnlyCollection<TEnum>? _all;

    public static IReadOnlyCollection<TEnum> GetAll() =>
        _all ??= [.. typeof(TEnum)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => (TEnum)f.GetValue(null)!)];

    public static TEnum FromName(string name) =>
        GetAll().Single(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));

    public static TEnum FromValue(int value) =>
        GetAll().Single(x => x.Value == value);

    public static bool TryFromName(
        string name,
        out TEnum? result)
    {
        result = GetAll().FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));

        return result is not null;
    }

    public static bool TryFromValue(
        int value,
        out TEnum? result)
    {
        result = GetAll().FirstOrDefault(x => x.Value == value);

        return result is not null;
    }
}
