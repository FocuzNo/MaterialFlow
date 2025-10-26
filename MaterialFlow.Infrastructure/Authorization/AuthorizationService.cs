using MaterialFlow.Application.Abstractions.Caching;
using MaterialFlow.Domain.Users;

namespace MaterialFlow.Infrastructure.Authorization;

internal sealed class AuthorizationService(
    ApplicationDbContext dbContext,
    ICacheService cache)
{
    public async Task<UserRolesResponse> GetRolesForUserAsync(string identityId)
    {
        var cacheKey = $"auth:roles:{identityId}";

        if (await cache.GetAsync<UserRolesResponse>(cacheKey) is { } cachedRoles)
        {
            return cachedRoles;
        }

        var userRoles = await dbContext.Set<User>()
            .Where(u => u.IdentityId == identityId)
            .Select(u => new UserRolesResponse
            {
                UserId = u.Id,
                Roles = u.Roles.ToList()
            })
            .AsNoTracking()
            .FirstAsync();

        await cache.SetAsync(
            cacheKey,
            userRoles);

        return userRoles;
    }

    public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    {
        var cacheKey = $"auth:permissions:{identityId}";

        if (await cache.GetAsync<HashSet<string>>(cacheKey) is { } cachedPermissions)
        {
            return cachedPermissions;
        }

        var permissions = await dbContext.Set<User>()
            .Where(u => u.IdentityId == identityId)
            .SelectMany(u => u.Roles.SelectMany(r => r.Permissions))
            .Select(p => p.Name)
            .AsNoTracking()
            .ToHashSetAsync();

        await cache.SetAsync(
            cacheKey,
            permissions);

        return permissions;
    }
}