using MaterialFlow.Domain.ForecastPlanItems;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class ForecastPlanItemConfiguration : BaseEntityConfiguration<ForecastPlanItem>
{
    public override void Configure(EntityTypeBuilder<ForecastPlanItem> builder)
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

        builder.Property(x => x.ConsumptionIndicator)
            .HasMaxLength(50);
    }
}
