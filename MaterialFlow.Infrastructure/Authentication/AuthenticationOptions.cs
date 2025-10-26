namespace MaterialFlow.Infrastructure.Authentication;

public sealed record AuthenticationOptions(
    string Audience,
    string MetadataUrl,
    bool RequireHttpsMetadata,
    string Issuer);