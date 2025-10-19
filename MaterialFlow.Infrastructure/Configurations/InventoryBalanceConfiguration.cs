using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class InventoryBalanceConfiguration : BaseEntityConfiguration<InventoryBalance>
{
    public override void Configure(EntityTypeBuilder<InventoryBalance> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.OnHand, onHand =>
        {
            onHand.Property(p => p.Amount)
                .HasPrecision(21, 3);

            onHand.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(p => p.Value)
                    .HasMaxLength(20);
            });
        });

        builder.OwnsOne(x => x.Reserved, reserved =>
        {
            reserved.Property(p => p.Amount)
                .HasPrecision(21, 3);

            reserved.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(p => p.Value)
                    .HasMaxLength(20);
            });
        });

        builder.Property(x => x.Batch)
            .HasMaxLength(50);
    }
}
