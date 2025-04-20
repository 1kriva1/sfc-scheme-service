using SFC.Scheme.Application.Interfaces.Cache;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Scheme.Domain.Entities.Team.Data;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Team.Data.Cache;
public class TeamPlayerStatusCacheRepository(TeamPlayerStatusRepository repository, ICache cache)
    : TeamDataCacheRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(repository, cache), ITeamPlayerStatusRepository
{ }