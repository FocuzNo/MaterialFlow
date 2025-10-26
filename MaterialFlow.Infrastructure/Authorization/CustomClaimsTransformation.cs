using MaterialFlow.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MaterialFlow.Infrastructure.Authorization;

internal sealed class CustomClaimsTransformation(IServiceProvider serviceProvider)
    : IClaimsTransformation
{
    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        if (principal.Identity is not { IsAuthenticated: true } ||
            principal.HasClaim(claim => claim.Type == ClaimTypes.Role) &&
            principal.HasClaim(claim => claim.Type == JwtRegisteredClaimNames.Sub))
        {
            return principal;
        }

        using IServiceScope scope = serviceProvider.CreateScope();

        var authorizationService = scope
            .ServiceProvider
            .GetRequiredService<AuthorizationService>();

        string identityId = principal.GetIdentityId();

        UserRolesResponse userRoles = await authorizationService.GetRolesForUserAsync(identityId);

        var claimsIdentity = new ClaimsIdentity();

        claimsIdentity
            .AddClaim(new Claim(
                JwtRegisteredClaimNames.Sub,
                userRoles.UserId.ToString()));

        foreach (Role role in userRoles.Roles)
        {
            claimsIdentity
                .AddClaim(new Claim(
                    ClaimTypes.Role,
                    role.Name));
        }

        principal.AddIdentity(claimsIdentity);

        return principal;
    }
}