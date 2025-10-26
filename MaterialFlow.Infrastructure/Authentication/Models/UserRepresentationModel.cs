using MaterialFlow.Domain.Users;

namespace MaterialFlow.Infrastructure.Authentication.Models;

internal sealed record class UserRepresentationModel
{
    public Dictionary<string, string> Access { get; init; }

    public Dictionary<string, List<string>> Attributes { get; init; }

    public Dictionary<string, string> ClientRoles { get; init; }

    public long? CreatedTimestamp { get; init; }

    public CredentialRepresentationModel[] Credentials { get; init; }

    public string[] DisableableCredentialTypes { get; init; }

    public string Email { get; init; }

    public bool? EmailVerified { get; init; }

    public bool? Enabled { get; init; }

    public string FederationLink { get; init; }

    public string Id { get; init; }

    public string[] Groups { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public int? NotBefore { get; init; }

    public string Origin { get; init; }

    public string[] RealmRoles { get; init; }

    public string[] RequiredActions { get; init; }

    public string Self { get; init; }

    public string ServiceAccountClientId { get; init; }

    public string Username { get; init; }

    internal static UserRepresentationModel FromUser(User user)
    {
        return new()
        {
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value,
            Email = user.Email.Value,
            Username = user.Email.Value,
            Enabled = true,
            EmailVerified = true,
            CreatedTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            Attributes = [],
            RequiredActions = []
        };
    }
}