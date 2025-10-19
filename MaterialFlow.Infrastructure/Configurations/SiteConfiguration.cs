using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class SiteConfiguration : BaseEntityConfiguration<Site>
{
    public override void Configure(EntityTypeBuilder<Site> builder)
    {
        base.Configure(builder);

        builder.HasIndex(x => x.PlantCode)
            .IsUnique();

        builder.Property(x => x.PlantCode)
            .HasMaxLength(10);

        builder.Property(x => x.Name)
            .HasMaxLength(100);
    }
}