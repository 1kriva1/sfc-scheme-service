using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Common.Settings;
using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Infrastructure.Cache;
using SFC.Scheme.Infrastructure.Services.Cache;

namespace SFC.Scheme.Infrastructure.Extensions;
public static class CacheExtensions
{
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.Configure<CacheSettings>(configuration.GetSection(CacheSettings.SectionKey));
        services.AddScoped<ICache, RedisCache>();
        services.AddScoped<IRefreshCache, RefreshCacheService>();

        return services;
    }
}