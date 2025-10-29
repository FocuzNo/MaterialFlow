using MaterialFlow.Application.Abstractions.Caching;
using Microsoft.Extensions.Logging;

namespace MaterialFlow.Application.Abstractions.Behaviors;

internal sealed class QueryCachingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICachedQuery
    where TResponse : Result
{
    private readonly ICacheService _cache;
    private readonly ILogger<QueryCachingBehavior<TRequest, TResponse>> _logger;

    public QueryCachingBehavior(
        ICacheService cache,
        ILogger<QueryCachingBehavior<TRequest, TResponse>> logger)
    {
        ArgumentNullException.ThrowIfNull(cache);
        ArgumentNullException.ThrowIfNull(logger);

        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        ArgumentNullException.ThrowIfNull(next);

        var queryName = typeof(TRequest).Name;

        var cached = await _cache.GetAsync<TResponse>(request.CacheKey, cancellationToken);
        if (cached is not null)
        {
            _logger.LogInformation("Cache hit: {Query}", queryName);
            return cached;
        }

        _logger.LogInformation("Cache miss: {Query}", queryName);

        var result = await next();

        if (result.IsSuccess)
        {
            await _cache.SetAsync(request.CacheKey, result, request.Expiration, cancellationToken);
            _logger.LogInformation("Cached: {Query}", queryName);
        }

        return result;
    }
}