namespace MaterialFlow.Infrastructure.Authentication;

public sealed class AuthenticationOptions
{
    public string Audience { get; private set; }

    public string MetadataUrl { get; private set; }

    public bool RequireHttpsMetadata { get; private init; }

    public string Issuer { get; private set; }
}
