using Microsoft.Extensions.DependencyInjection;

using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Scheme.Domain.Entities.Team.Data;
using SFC.Scheme.Infrastructure.Persistence.Constants;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamPlayerStatusCacheRepository(TeamPlayerStatusRepository repository, [FromKeyedServices(CacheInstance.Team)] ICache cache)
    : TeamDataCacheRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(repository, cache), ITeamPlayerStatusRepository
{ }