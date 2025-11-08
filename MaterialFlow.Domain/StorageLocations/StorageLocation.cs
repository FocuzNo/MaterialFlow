using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.StorageLocations;

public sealed class StorageLocation : Entity
{
    private StorageLocation() { }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public string Code { get; private set; }

    public string Name { get; private set; }

    public static StorageLocation Create(
        Guid id,
        Guid siteId,
        string code,
        string name)
        => new()
        {
            Id = id,
            SiteId = siteId,
            Code = code,
            Name = name
        };

    public void Update(
        string code,
        string name)
    {
        Code = code;
        Name = name;
    }
}