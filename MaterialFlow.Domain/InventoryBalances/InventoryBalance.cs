using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Shared.ValueObjects;
using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.InventoryBalances;

public sealed class InventoryBalance : Entity
{
    private InventoryBalance() { }

    public Guid MaterialId { get; private set; }
    public Material Material { get; private set; }

    public Guid SiteId { get; private set; }
    public Site Site { get; private set; }

    public Guid? StorageLocationId { get; private set; }

    public StorageLocation? StorageLocation { get; private set; }

    public Quantity OnHand { get; private set; }

    public Quantity Reserved { get; private set; }

    public string? Batch { get; private set; }

    public static InventoryBalance Create(
        Guid id,
        Guid materialId,
        Guid siteId,
        Guid? storageLocationId,
        Quantity onHand,
        Quantity reserved,
        string? batch)
        => new()
        {
            Id = id,
            MaterialId = materialId,
            SiteId = siteId,
            StorageLocationId = storageLocationId,
            OnHand = onHand,
            Reserved = reserved,
            Batch = batch
        };

    public void Update(
        Quantity onHand,
        Quantity reserved,
        string? batch)
    {
        OnHand = onHand;
        Reserved = reserved;
        Batch = batch;
    }
}
