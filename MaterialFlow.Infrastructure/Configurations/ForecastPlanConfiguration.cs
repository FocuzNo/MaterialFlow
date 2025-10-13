using MaterialFlow.Domain.ForecastPlans;
using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Infrastructure.Configurations;

public sealed class ForecastPlanConfiguration : IEntityTypeConfiguration<ForecastPlan>
{
    public void Configure(EntityTypeBuilder<ForecastPlan> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Version)
            .HasMaxLength(50);

        builder.Property(x => x.PlanningStrategy)
            .HasMaxLength(50);

        builder.OwnsOne(x => x.UnitOfMeasure, uom =>
        {
            uom.Property(p => p.Value)
               .HasMaxLength(20);
        });

        builder.Property(x => x.PeriodGranularity)
            .HasConversion(
                x => x.Value,
                x => PeriodGranularity.FromValue(x))
            .HasMaxLength(2);

        builder.OwnsOne(x => x.DateRange, dr =>
        {
            dr.Property(p => p.StartDate);
            dr.Property(p => p.EndDate);
        });
    }
}
