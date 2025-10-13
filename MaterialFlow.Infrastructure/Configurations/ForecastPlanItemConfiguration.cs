using MaterialFlow.Domain.ForecastPlans;

namespace MaterialFlow.Infrastructure.Configurations;

public sealed class ForecastPlanItemConfiguration : IEntityTypeConfiguration<ForecastPlanItem>
{
    public void Configure(EntityTypeBuilder<ForecastPlanItem> builder)
    {
        builder.HasKey(x => x.Id);

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

        builder.Property(x => x.ConsumptionIndicator)
            .HasMaxLength(50);
    }
}
