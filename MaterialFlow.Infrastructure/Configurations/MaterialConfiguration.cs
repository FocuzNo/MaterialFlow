using MaterialFlow.Domain.Materials;
using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Infrastructure.Configurations;

public sealed class MaterialConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.MaterialNumber, x =>
        {
            x.Property(x => x.Value)
            .HasMaxLength(50);
        });

        builder.Property(x => x.Description)
            .HasMaxLength(250);

        builder.Property(x => x.BaseUnitOfMeasure)
            .HasConversion(
                x => x.Value,
                x => new UnitOfMeasure(x))
            .HasMaxLength(20);

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

        builder.OwnsOne(x => x.SafetyStockQuantity, x =>
        {
            x.Property(p => p.Amount)
             .HasPrecision(18, 3);
        });

        builder.Ignore(x => x.GetDomainEvents());
    }
}