using MaterialFlow.Infrastructure.Authentication;
using MaterialFlow.Infrastructure.Authentication.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Http.Headers;
using System.Net.Http.Json;

internal sealed class AdminAuthorizationDelegatingHandler(
    IHttpClientFactory httpClientFactory,
    KeycloakOptions keycloakOptions) : DelegatingHandler
{
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
            keycloakOptions.TokenUrl)
        {
            Content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("client_id", keycloakOptions.AdminClientId),
                new KeyValuePair<string, string>("client_secret", keycloakOptions.AdminClientSecret),
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            ])
        };

        var httpClient = httpClientFactory.CreateClient("keycloak");

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
            throw new ApplicationException("Keycloak token response is empty or invalid.");
        }

        return token.AccessToken;
    }
}