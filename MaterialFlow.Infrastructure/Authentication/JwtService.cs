using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Infrastructure.Authentication.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace MaterialFlow.Infrastructure.Authentication;

internal sealed class JwtService(HttpClient http, IOptions<KeycloakOptions> options) : IJwtService
{
    private static readonly Error AuthFailed = new(
        "Keycloak.AuthenticationFailed",
        "Failed to acquire access token due to authentication failure");

    private readonly KeycloakOptions _opts = options.Value;

    public async Task<Result<string>> GetAccessTokenAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var parameters = new[]
            {
                new KeyValuePair<string, string>("client_id", _opts.AuthClientId),
                new KeyValuePair<string, string>("client_secret", _opts.AuthClientSecret),
                new KeyValuePair<string, string>("scope", "openid email"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", password)
            };

            using var content = new FormUrlEncodedContent(parameters);

            var result = await http.PostAsync(
                string.Empty,
                content,
                cancellationToken);

            result.EnsureSuccessStatusCode();

            var token = await result.Content.ReadFromJsonAsync<AuthorizationToken>(cancellationToken);

            return token is not null
                ? token.AccessToken
                : Result.Failure<string>(AuthFailed);
        }
        catch (HttpRequestException)
        {
            return Result.Failure<string>(AuthFailed);
        }
    }
}