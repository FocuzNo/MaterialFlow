using MaterialFlow.Domain.StorageLocations;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class StorageLocationConfiguration : BaseEntityConfiguration<StorageLocation>
{
    public override void Configure(EntityTypeBuilder<StorageLocation> builder)
    {
        base.Configure(builder);

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.Property(x => x.Code)
            .HasMaxLength(20);

        builder.Property(x => x.Name)
            .HasMaxLength(100);
    }
}