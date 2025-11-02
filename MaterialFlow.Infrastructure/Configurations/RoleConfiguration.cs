using MaterialFlow.Domain.Users;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.HasData(
            Role.Administrator,
            Role.Planner,
            Role.Viewer);
    }
}