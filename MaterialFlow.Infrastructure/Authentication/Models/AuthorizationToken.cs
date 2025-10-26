using System.Text.Json.Serialization;

namespace MaterialFlow.Infrastructure.Authentication.Models;

internal sealed class AuthorizationToken
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; init; }
}