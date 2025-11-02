using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

internal sealed class CustomClaimsTransformation : IClaimsTransformation
{
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        if (principal.Identity is not { IsAuthenticated: true })
            return Task.FromResult(principal);

        if (principal.HasClaim(c => c.Type == ClaimTypes.Role))
            return Task.FromResult(principal);

        var resourceAccess = principal.FindFirst("resource_access")?.Value;

        if (!string.IsNullOrEmpty(resourceAccess))
        {
            using var doc = JsonDocument.Parse(resourceAccess);
            if (doc.RootElement.TryGetProperty("materialflow-api", out var api) &&
                api.TryGetProperty("roles", out var roles) &&
                roles.ValueKind == JsonValueKind.Array)
            {
                var id = new ClaimsIdentity();
                foreach (var r in roles.EnumerateArray())
                {
                    var name = r.GetString();
                    if (!string.IsNullOrWhiteSpace(name))
                        id.AddClaim(new Claim(ClaimTypes.Role, name));
                }
                if (id.Claims.Any())
                    principal.AddIdentity(id);
            }
        }

        return Task.FromResult(principal);
    }
}