using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data.Cache;
public class SchemeTypeCacheRepository(SchemeTypeRepository repository, [FromKeyedServices(CacheInstance.Scheme)] ICache cache)
    : SchemeDataCacheRepository<SchemeType, SchemeTypeEnum>(repository, cache), ISchemeTypeRepository
{ }