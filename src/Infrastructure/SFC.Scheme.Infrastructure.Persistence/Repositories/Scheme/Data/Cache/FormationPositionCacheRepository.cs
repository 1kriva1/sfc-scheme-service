
using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data.Cache;
public class FormationPositionCacheRepository(FormationPositionRepository repository, [FromKeyedServices(CacheInstance.Scheme)] ICache cache)
    : SchemeDataCacheRepository<FormationPosition, FormationPositionEnum>(repository, cache), IFormationPositionRepository
{ }