using Microsoft.Extensions.Caching.Distributed;

namespace MaterialFlow.Infrastructure.Caching;

public static class CacheOptions
{
    private static readonly TimeSpan DefaultTtl = TimeSpan.FromMinutes(1);

    public static DistributedCacheEntryOptions DefaultExpiration => new()
    {
        AbsoluteExpirationRelativeToNow = DefaultTtl
    };

    public static DistributedCacheEntryOptions Create(TimeSpan? expiration) =>
        expiration is null
            ? DefaultExpiration
            : new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiration };
}