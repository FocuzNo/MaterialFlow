using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class MaterialConfiguration : BaseEntityConfiguration<Material>
{
    public override void Configure(EntityTypeBuilder<Material> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.MaterialNumber, mn =>
        {
            mn.Property(p => p.Value)
                .HasMaxLength(50);
        });

        builder.OwnsOne(x => x.UnitOfMeasure, uom =>
        {
            uom.Property(p => p.Value)
               .HasMaxLength(20);
        });

        builder.OwnsOne(x => x.SafetyStockQuantity, ssq =>
        {
            ssq.Property(p => p.Amount)
                .HasPrecision(18, 3);

            ssq.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(p => p.Value)
                    .HasMaxLength(20);
            });
        });

        builder.Property(x => x.Description)
            .HasMaxLength(250);

        builder.Property(x => x.MaterialRequirementsPlanningType)
            .HasConversion(
                x => x.Name,
                x => MaterialRequirementsPlanningType.FromName(x))
            .HasMaxLength(50);

        builder.Property(x => x.LotSizePolicy)
            .HasConversion(
                x => x.Name,
                x => LotSizePolicy.FromName(x))
            .HasMaxLength(50);

        builder.Property(x => x.ProcurementType)
            .HasConversion(
                x => x.Name,
                x => ProcurementType.FromName(x))
            .HasMaxLength(50);
    }
}
