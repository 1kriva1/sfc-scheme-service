using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using SFC.Scheme.Application.Common.Settings;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Cache;

public class RedisDataCache([FromKeyedServices(CacheInstance.Data)] IDistributedCache cache, IOptions<CacheSettings> cacheConfig)
    : RedisCache(cache, cacheConfig)
{ }