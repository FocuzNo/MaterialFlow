namespace MaterialFlow.Domain.Sites;

public sealed class Site : Entity
{
    private Site() { }

    public string PlantCode { get; private set; }

    public string Name { get; private set; }

    public static Site Create(
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
