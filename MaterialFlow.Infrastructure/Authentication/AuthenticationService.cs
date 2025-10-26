using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Domain.Users;
using MaterialFlow.Infrastructure.Authentication.Models;
using System.Net.Http.Json;

namespace MaterialFlow.Infrastructure.Authentication;

internal sealed class AuthenticationService(HttpClient http) : IAuthenticationService
{
    private const string PasswordCredentialType = "password";

    public async Task<string> RegisterAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default)
    {
        var model = UserRepresentationModel.FromUser(user) with
        {
            Credentials =
            [
                new()
                {
                    Value = password,
                    Temporary = false,
                    Type = PasswordCredentialType
                }
            ]
        };

        var response = await http.PostAsJsonAsync("users", model, cancellationToken);
        return ExtractIdentityId(response);
    }

    private static string ExtractIdentityId(HttpResponseMessage response)
    {
        const string segment = "users/";

        string? path = response.Headers.Location?.PathAndQuery
            ?? throw new InvalidOperationException("Location header can't be null");

        int idx = path.IndexOf(segment, StringComparison.InvariantCultureIgnoreCase);
        return path[(idx + segment.Length)..];
    }
}