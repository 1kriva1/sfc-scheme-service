using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Domain.Common;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data.Cache;
public class SchemeDataCacheRepository<TEntity, TEnum>(SchemeDataRepository<TEntity, TEnum> repository, ICache cache)
    : DataCacheRepository<TEntity, SchemeDbContext, TEnum>(repository, cache)
     where TEntity : EnumDataEntity<TEnum>
     where TEnum : struct
{ }