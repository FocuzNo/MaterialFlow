namespace MaterialFlow.Domain.Users;

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

    public static readonly Role Administrator = new(1, nameof(Administrator));
    public static readonly Role Planner = new(2, nameof(Planner));
    public static readonly Role Viewer = new(3, nameof(Viewer));

    public int Id { get; private set; }

    public string Name { get; private set; }

    public ICollection<User> Users { get; private set; } = [];

    public ICollection<Permission> Permissions { get; private set; } = [];
}