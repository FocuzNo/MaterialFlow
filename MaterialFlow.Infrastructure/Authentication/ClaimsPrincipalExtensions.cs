using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace MaterialFlow.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        if (principal is null || principal.Identity?.IsAuthenticated != true)
        {
            throw new ApplicationException("User is not authenticated");
        }

        var userId = principal.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return Guid.TryParse(userId, out var parsedId)
            ? parsedId
            : throw new ApplicationException("User ID (sub) is unavailable or invalid");
    }

    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        if (principal is null || principal.Identity?.IsAuthenticated != true)
        {
            throw new ApplicationException("User is not authenticated");
        }

        var identityId =
            principal.FindFirstValue("sub")
            ?? principal.FindFirstValue(JwtRegisteredClaimNames.Sub)
            ?? principal.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrWhiteSpace(identityId))
        {
            throw new ApplicationException("User identity (sub) is unavailable");
        }

        return identityId;
    }
}