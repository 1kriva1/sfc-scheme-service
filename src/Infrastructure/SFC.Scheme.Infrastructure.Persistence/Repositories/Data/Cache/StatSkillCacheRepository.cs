using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Domain.Entities.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data.Cache;
public class StatSkillCacheRepository(StatSkillRepository repository, ICache cache)
    : DataCacheRepository<StatSkill, StatSkillEnum>(repository, cache), IStatSkillRepository
{ }