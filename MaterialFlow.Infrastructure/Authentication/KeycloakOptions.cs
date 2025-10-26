namespace MaterialFlow.Infrastructure.Authentication;

public sealed class KeycloakOptions
{
    public string AdminUrl { get; set; }

    public string TokenUrl { get; set; }

    public string AdminClientId { get; init; }

    public string AdminClientSecret { get; init; }

    public string AuthClientId { get; init; }

    public string AuthClientSecret { get; init; }
}