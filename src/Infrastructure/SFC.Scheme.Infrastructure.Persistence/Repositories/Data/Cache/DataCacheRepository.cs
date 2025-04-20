using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Domain.Common;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data.Cache;
public class DataCacheRepository<TEntity, TEnum>(DataRepository<TEntity, TEnum> repository, ICache cache)
    : DataCacheRepository<TEntity, DataDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }