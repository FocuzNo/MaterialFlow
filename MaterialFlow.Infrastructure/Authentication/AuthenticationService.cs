using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Domain.Users;
using MaterialFlow.Infrastructure.Authentication.Models;
using System.Net.Http.Json;

namespace MaterialFlow.Infrastructure.Authentication;

internal sealed class AuthenticationService(HttpClient httpClient) : IAuthenticationService
{
    private const string PasswordCredentialType = "password";

    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> RegisterAsync(
        User user,
        string password,
        CancellationToken cancellationToken = default)
    {
        var userRepresentationModel = UserRepresentationModel.FromUser(user);

        userRepresentationModel.Credentials =
        [
        new()
        {
            Value = password,
            Temporary = false,
            Type = PasswordCredentialType
        }
        ];

        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            "users",
            userRepresentationModel,
            cancellationToken);

        return ExtractIdentityIdFromLocationHeader(response);
    }

    private static string ExtractIdentityIdFromLocationHeader(HttpResponseMessage httpResponseMessage)
    {
        const string usersSegmentName = "users/";

        string? locationHeader = httpResponseMessage.Headers.Location?.PathAndQuery;

        if (locationHeader is null)
        {
            throw new InvalidOperationException("Location header can't be null");
        }

        int userSegmentValueIndex = locationHeader.IndexOf(
            usersSegmentName,
            StringComparison.InvariantCultureIgnoreCase);

        string userIdentityId = locationHeader[
            (userSegmentValueIndex + usersSegmentName.Length)..];

        return userIdentityId;
    }
}