using SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.Data;
using SFC.Scheme.Domain.Entities.Team.Data;
using SFC.Scheme.Infrastructure.Persistence.Contexts;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Team.Data;
public class TeamPlayerStatusRepository(TeamDbContext context)
    : TeamDataRepository<TeamPlayerStatus, TeamPlayerStatusEnum>(context), ITeamPlayerStatusRepository
{ }