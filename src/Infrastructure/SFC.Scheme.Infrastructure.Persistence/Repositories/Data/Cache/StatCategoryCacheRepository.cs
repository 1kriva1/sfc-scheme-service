using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Domain.Entities.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data.Cache;
public class StatCategoryCacheRepository(StatCategoryRepository repository, ICache cache)
    : DataCacheRepository<StatCategory, StatCategoryEnum>(repository, cache), IStatCategoryRepository
{ }