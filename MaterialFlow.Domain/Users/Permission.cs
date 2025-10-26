namespace MaterialFlow.Domain.Users;

public sealed class Permission(
    int Id,
    string Name)
{
    public static readonly Permission MaterialsRead = new(1, "materials:read");
    public static readonly Permission MaterialsWrite = new(2, "materials:write");
    public static readonly Permission SitesRead = new(3, "sites:read");
    public static readonly Permission SitesWrite = new(4, "sites:write");
    public static readonly Permission UsersRead = new(5, "users:read");
    public static readonly Permission UsersWrite = new(6, "users:write");

    public int Id { get; init; }

    public string Name { get; init; }
}