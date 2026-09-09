using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Domain.Common;
using SFC.Scheme.Infrastructure.Persistence.Constants;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Game.Data.Cache;
public class GameDataCacheRepository<TEntity, TEnum>(GameDataRepository<TEntity, TEnum> repository, [FromKeyedServices(CacheInstance.Game)] ICache cache)
    : DataRelatedCacheRepository<TEntity, GameDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }