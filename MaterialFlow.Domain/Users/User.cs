using MaterialFlow.Domain.Users.Events;
using MaterialFlow.Domain.Users.ValueObjects;

namespace MaterialFlow.Domain.Users;

public sealed class User : Entity
{
    private readonly List<Role> _roles = [];

    private User() { }

    public Email Email { get; private set; }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public string PasswordHash { get; private set; }

    public string IdentityId { get; private set; }

    public bool IsActive { get; private set; } = true;

    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

    public static User Create(
        Guid id,
        Email email,
        FirstName firstName,
        LastName lastName,
        string passwordHash)
    {
        var user = new User
        {
            Id = id,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            PasswordHash = passwordHash,
            IsActive = true,
            IdentityId = string.Empty
        };

        user._roles.Add(Role.Viewer);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }

    public void Update(
        Email email,
        FirstName firstName,
        LastName lastName)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;

        RaiseDomainEvent(new UserUpdatedDomainEvent(Id));
    }

    public void SetIdentityId(string identityId)
    {
        IdentityId = identityId;
    }
}