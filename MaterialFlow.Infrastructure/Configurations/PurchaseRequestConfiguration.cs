using MaterialFlow.Domain.PurchaseRequests;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class PurchaseRequestConfiguration : BaseEntityConfiguration<PurchaseRequest>
{
    public override void Configure(EntityTypeBuilder<PurchaseRequest> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.Quantity, q =>
        {
            q.Property(p => p.Amount)
                .HasPrecision(21, 3);

            q.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(p => p.Value)
                    .HasMaxLength(20);
            });
        });

        builder.OwnsOne(x => x.UnitOfMeasure, uom =>
        {
            uom.Property(p => p.Value)
                .HasMaxLength(20);
        });

        builder.Property(x => x.PurchasingGroup)
            .HasMaxLength(50);

        builder.Property(x => x.OrderStatus)
            .HasConversion(
                x => x.Name,
                x => OrderStatus.FromName(x))
            .HasMaxLength(50);
    }
}