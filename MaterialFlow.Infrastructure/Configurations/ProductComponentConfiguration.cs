using MaterialFlow.Domain.ProductComponents;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class ProductComponentConfiguration : BaseEntityConfiguration<ProductComponent>
{
    public override void Configure(EntityTypeBuilder<ProductComponent> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.UnitOfMeasure, uom =>
        {
            uom.Property(p => p.Value)
                .HasMaxLength(20);
        });

        builder.OwnsOne(x => x.QuantityPer, qp =>
        {
            qp.Property(p => p.Amount)
                .HasPrecision(21, 3);

            qp.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(p => p.Value)
                    .HasMaxLength(20);
            });
        });

        builder.Property(x => x.ScrapPercentage)
            .HasPrecision(7, 2);
    }
}