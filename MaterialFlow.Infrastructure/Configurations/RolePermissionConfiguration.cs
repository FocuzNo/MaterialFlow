using MaterialFlow.Domain.Users;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.HasKey(x => new
        {
            x.RoleId,
            x.PermissionId
        });
    }
}