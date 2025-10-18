using MaterialFlow.Domain.PlanningAreas;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class PlanningAreaConfiguration : BaseEntityConfiguration<PlanningArea>
{
    public override void Configure(EntityTypeBuilder<PlanningArea> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.PlanningAreaCode)
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .HasMaxLength(250);
    }
}
