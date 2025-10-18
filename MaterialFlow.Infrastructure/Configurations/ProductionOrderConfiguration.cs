using MaterialFlow.Domain.ProductionOrders;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class ProductionOrderConfiguration : BaseEntityConfiguration<ProductionOrder>
{
    public override void Configure(EntityTypeBuilder<ProductionOrder> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.QuantityToProduce, qtp =>
        {
            qtp.Property(p => p.Amount)
                .HasPrecision(21, 3);

            qtp.OwnsOne(p => p.UnitOfMeasure, uom =>
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

        builder.Property(x => x.OrderStatus)
            .HasConversion(
                x => x.Name,
                x => OrderStatus.FromName(x))
            .HasMaxLength(50);
    }
}