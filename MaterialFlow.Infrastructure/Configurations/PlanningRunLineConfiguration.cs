using MaterialFlow.Domain.PlanningRunLines;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class PlanningRunLineConfiguration : BaseEntityConfiguration<PlanningRunLine>
{
    public override void Configure(EntityTypeBuilder<PlanningRunLine> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.RequirementQuantity, rq =>
        {
            rq.Property(p => p.Amount)
                .HasPrecision(21, 3);

            rq.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(p => p.Value)
                    .HasMaxLength(20);
            });
        });

        builder.OwnsOne(x => x.AvailableQuantity, aq =>
        {
            aq.Property(p => p.Amount)
                .HasPrecision(21, 3);

            aq.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(p => p.Value)
                    .HasMaxLength(20);
            });
        });

        builder.OwnsOne(x => x.ShortageQuantity, sq =>
        {
            sq.Property(p => p.Amount)
                .HasPrecision(21, 3);

            sq.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(p => p.Value)
                    .HasMaxLength(20);
            });
        });

        builder.Property(x => x.RecommendedAction)
            .HasMaxLength(100);
    }
}