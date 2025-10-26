using MaterialFlow.Infrastructure.Authentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MaterialFlow.Infrastructure.Authentication;

internal sealed class AdminAuthorizationDelegatingHandler(IOptions<KeycloakOptions> keycloakOptions)
    : DelegatingHandler
{
    private readonly KeycloakOptions _opts = keycloakOptions.Value;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await GetAuthorizationToken(cancellationToken);

        request.Headers.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token.AccessToken);

        var response = await base.SendAsync(
            request,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return response;
    }

    private async Task<AuthorizationToken> GetAuthorizationToken(CancellationToken cancellationToken)
    {
        var parameters = new[]
        {
            new KeyValuePair<string, string>("client_id", _opts.AdminClientId),
            new KeyValuePair<string, string>("client_secret", _opts.AdminClientSecret),
            new KeyValuePair<string, string>("scope", "openid email"),
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        };

        using var request = new HttpRequestMessage(
            HttpMethod.Post,
            _opts.TokenUrl)
        {
            Content = new FormUrlEncodedContent(parameters)
        };

        var res = await base.SendAsync(request,
            cancellationToken);

        res.EnsureSuccessStatusCode();

        return await res.Content.ReadFromJsonAsync<AuthorizationToken>(cancellationToken)
            ?? throw new ApplicationException("Token acquisition failed");
    }
}