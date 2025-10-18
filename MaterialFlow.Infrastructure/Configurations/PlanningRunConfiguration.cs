using MaterialFlow.Domain.PlanningRuns;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class PlanningRunConfiguration : BaseEntityConfiguration<PlanningRun>
{
    public override void Configure(EntityTypeBuilder<PlanningRun> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.StartedByUser)
            .HasMaxLength(100);

        builder.Property(x => x.OrderStatus)
            .HasConversion(
                x => x.Name,
                x => OrderStatus.FromName(x))
            .HasMaxLength(50);

        builder.Navigation(x => x.Lines)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
