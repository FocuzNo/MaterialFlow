using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace MaterialFlow.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal? principal)
    {
        var userId = principal?.FindFirstValue(JwtRegisteredClaimNames.Sub);

        return Guid.TryParse(userId, out var id)
            ? id
            : throw new ApplicationException("User id is unavailable");
    }

    public static string GetIdentityId(this ClaimsPrincipal? principal) =>
        principal?.FindFirstValue(ClaimTypes.NameIdentifier)
        ?? throw new ApplicationException("User identity is unavailable");
}