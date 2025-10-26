using MaterialFlow.Domain.Users;

public sealed class Role
{
    private Role() { }

    public Role(
        int id,
        string name)
    {
        Id = id;
        Name = name;
    }

    public static readonly Role Administrator = new(1, "Administrator");
    public static readonly Role Planner = new(2, "Planner");
    public static readonly Role Viewer = new(3, "Viewer");

    public int Id { get; private set; }

    public string Name { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    public ICollection<Permission> Permissions { get; private set; } = [];
}