using MaterialFlow.Domain.PlannedProductionOrders;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class PlannedProductionOrderConfiguration : BaseEntityConfiguration<PlannedProductionOrder>
{
    public override void Configure(EntityTypeBuilder<PlannedProductionOrder> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Quantity)
            .HasPrecision(18, 3);

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