using MaterialFlow.Domain.SalesOrderDemands;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class SalesOrderDemandConfiguration : BaseEntityConfiguration<SalesOrderDemand>
{
    public override void Configure(EntityTypeBuilder<SalesOrderDemand> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.Quantity, q =>
        {
            q.Property(p => p.Amount)
                .HasPrecision(18, 3);

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

        builder.OwnsOne(x => x.SourceDocument, sd =>
        {
            sd.Property(p => p.Type)
                .HasMaxLength(50);

            sd.Property(p => p.Number)
                .HasMaxLength(50);

            sd.Property(p => p.ItemNumber)
                .HasMaxLength(50);
        });
    }
}