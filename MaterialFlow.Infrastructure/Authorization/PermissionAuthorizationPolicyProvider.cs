using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace MaterialFlow.Infrastructure.Authorization;

internal sealed class PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
    : DefaultAuthorizationPolicyProvider(options)
{
    private readonly AuthorizationOptions _options = options.Value;

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var existingPolicy = await base.GetPolicyAsync(policyName);

        if (existingPolicy is not null)
        {
            return existingPolicy;
        }

        var newPolicy = new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();

        _options.AddPolicy(
            policyName,
            newPolicy);

        return newPolicy;
    }
}
