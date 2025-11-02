using MaterialFlow.Infrastructure.Authentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MaterialFlow.Infrastructure.Authentication;

internal sealed class AdminAuthorizationDelegatingHandler(
    IHttpClientFactory httpClientFactory,
    IOptions<KeycloakOptions> options) : DelegatingHandler
{
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
    private readonly KeycloakOptions _options = options.Value;

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var accessToken = await AcquireAccessTokenAsync(cancellationToken);

        request.Headers.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            accessToken);

        return await base.SendAsync(
            request,
            cancellationToken);
    }

    private async Task<string> AcquireAccessTokenAsync(CancellationToken cancellationToken)
    {
        using var tokenRequest = new HttpRequestMessage(
            HttpMethod.Post,
            _options.TokenUrl)
        {
            Content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("client_id", _options.AdminClientId),
                new KeyValuePair<string, string>("client_secret", _options.AdminClientSecret),
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            ])
        };

        var httpClient = _httpClientFactory.CreateClient("keycloak");

        using var response = await httpClient.SendAsync(
            tokenRequest,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var details = await response.Content.ReadAsStringAsync(cancellationToken);

            throw new InvalidOperationException($"Keycloak token request failed {(int)response.StatusCode}: {details}");
        }

        var token = await response.Content.ReadFromJsonAsync<AuthorizationToken>(cancellationToken);

        if (token is null
            || string.IsNullOrWhiteSpace(token.AccessToken))
        {
            throw new InvalidOperationException("Keycloak token response is empty or invalid.");
        }

        return token.AccessToken;
    }
}