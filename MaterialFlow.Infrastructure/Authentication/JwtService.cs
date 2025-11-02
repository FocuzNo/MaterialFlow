using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Domain.Users;
using MaterialFlow.Infrastructure.Authentication.Models;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace MaterialFlow.Infrastructure.Authentication;

internal sealed class JwtService(
    HttpClient httpClient,
    IOptions<KeycloakOptions> options) : IJwtService
{
    public async Task<Result<string>> GetAccessTokenAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default)
    {
        using var content = new FormUrlEncodedContent(
        [
            new KeyValuePair<string, string>("client_id", options.Value.AuthClientId),
            new KeyValuePair<string, string>("client_secret", options.Value.AuthClientSecret),
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("username", email),
            new KeyValuePair<string, string>("password", password)
        ]);

        using var response = await httpClient.PostAsync(
            string.Empty,
            content,
            cancellationToken);

        if ((int)response.StatusCode >= 500)
        {
            return Result.Failure<string>(new Error(
                "Keycloak.Unavailable",
                "Identity provider is currently unavailable"));
        }

        if (!response.IsSuccessStatusCode)
        {
            return Result.Failure<string>(UserErrors.InvalidCredentials);
        }

        var token = await response.Content.ReadFromJsonAsync<AuthorizationToken>(cancellationToken);

        return token is null
            || string.IsNullOrWhiteSpace(token.AccessToken)
            ? Result.Failure<string>(new Error(
                "Keycloak.TokenParse",
                "Token response is empty or invalid"))
            : (Result<string>)token.AccessToken;
    }
}