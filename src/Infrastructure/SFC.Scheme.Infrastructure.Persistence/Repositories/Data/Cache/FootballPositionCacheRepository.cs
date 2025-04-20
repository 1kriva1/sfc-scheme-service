using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Domain.Entities.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data.Cache;
public class FootballPositionCacheRepository(FootballPositionRepository repository, ICache cache)
    : DataCacheRepository<FootballPosition, FootballPositionEnum>(repository, cache), IFootballPositionRepository
{ }