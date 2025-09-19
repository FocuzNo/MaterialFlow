namespace MaterialFlow.Domain.Plants;

public sealed class Plant : Entity
{
    public string PlantCode { get; private set; }

    public string Name { get; private set; }

    private Plant() { }

    public static Plant Create(
        Guid id,
        string plantCode,
        string name)
        => new()
        {
            Id = id,
            PlantCode = plantCode,
            Name = name
        };

    public void Update(
        string plantCode,
        string name)
    {
        PlantCode = plantCode;
        Name = name;
    }
}