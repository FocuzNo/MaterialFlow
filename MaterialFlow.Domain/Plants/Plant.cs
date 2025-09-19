namespace MaterialFlow.Domain.Plants;

public sealed class Plant : Entity
{
    public string PlantCode { get; private set; }

    public string Name { get; private set; }

    private Plant() { }

    public Plant(Guid identifier, string plantCode, string name)
    {
        Identifier = identifier;
        PlantCode = string.IsNullOrWhiteSpace(plantCode) ? throw new ArgumentException("PlantCode cannot be empty.", nameof(plantCode)) : plantCode;
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Name cannot be empty.", nameof(name)) : name;
    }
}