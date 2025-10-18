using MaterialFlow.Domain.ProductStructures;
using MaterialFlow.Domain.Materials.Enums;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class ProductStructureConfiguration : BaseEntityConfiguration<ProductStructure>
{
    public override void Configure(EntityTypeBuilder<ProductStructure> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Usage)
            .HasConversion(
                x => x.Name,
                x => BillOfMaterialsUsage.FromName(x))
            .HasMaxLength(50);

        builder.Property(x => x.AlternativeNumber)
            .HasMaxLength(10);

        builder.Property(x => x.OrderStatus)
            .HasConversion(
                x => x.Name,
                x => OrderStatus.FromName(x))
            .HasMaxLength(50);

        builder.Navigation(x => x.Components)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}