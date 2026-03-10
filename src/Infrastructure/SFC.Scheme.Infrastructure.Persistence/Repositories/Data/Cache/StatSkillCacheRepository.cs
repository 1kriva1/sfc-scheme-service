using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data.Cache;
public class StatSkillCacheRepository(StatSkillRepository repository, [FromKeyedServices(CacheInstance.Data)] ICache cache)
    : DataCacheRepository<StatSkill, StatSkillEnum>(repository, cache), IStatSkillRepository
{ }