using MaterialFlow.Domain.Users;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.HasMany(x => x.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>(
                rp => rp.HasOne<Permission>().WithMany().HasForeignKey(rp => rp.PermissionId),
                rp => rp.HasOne<Role>().WithMany().HasForeignKey(rp => rp.RoleId),
                rp =>
                {
                    rp.HasKey(e => new { e.RoleId, e.PermissionId });
                });
    }
}