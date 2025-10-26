namespace MaterialFlow.Domain.Users;

public sealed class RolePermission
{
    public int RoleId { get; private set; }

    public int PermissionId { get; private set; }
}