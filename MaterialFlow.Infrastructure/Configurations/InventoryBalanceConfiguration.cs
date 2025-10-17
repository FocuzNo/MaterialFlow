using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Infrastructure.Configurations;

public sealed class InventoryBalanceConfiguration : BaseEntityConfiguration<InventoryBalance>
{
    public override void Configure(EntityTypeBuilder<InventoryBalance> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.OnHand, q =>
        {
            q.Property(p => p.Amount)
                .HasPrecision(18, 3);

            q.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(u => u.Value)
                   .HasMaxLength(20);
            });
        });

        builder.OwnsOne(x => x.Reserved, q =>
        {
            q.Property(p => p.Amount)
                .HasPrecision(18, 3);

            q.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(u => u.Value)
                   .HasMaxLength(20);
            });
        });

        builder.Property(x => x.Batch)
            .HasMaxLength(50);
    }
}
