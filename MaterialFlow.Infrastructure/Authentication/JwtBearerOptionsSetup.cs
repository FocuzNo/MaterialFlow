using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace MaterialFlow.Infrastructure.Authentication;

internal sealed class JwtBearerOptionsSetup(IOptions<AuthenticationOptions> options)
    : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly AuthenticationOptions _options = options.Value;

    public void Configure(JwtBearerOptions opts)
    {
        opts.Audience = _options.Audience;
        opts.MetadataAddress = _options.MetadataUrl;
        opts.RequireHttpsMetadata = _options.RequireHttpsMetadata;
        opts.TokenValidationParameters.ValidIssuer = _options.Issuer;
    }

    public void Configure(
        string? name,
        JwtBearerOptions opts) => Configure(opts);
}