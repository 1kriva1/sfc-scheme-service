using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Team;
public class TeamSchemePlayerRepository(SchemeDbContext context)
    : Repository<TeamSchemeFormationPlayer, SchemeDbContext, long>(context), ITeamSchemePlayerRepository
{
    public async Task<IReadOnlyList<TeamSchemeFormationPlayer>> ListAllAsync(long teamId, long playerId)
    {
        return await Context.Set<TeamSchemeFormationPlayer>()
                            .Include(e => e.TeamSchemeFormation).ThenInclude(e => e.Scheme)
                            .Where(e => e.TeamSchemeFormation.Scheme.TeamId == teamId && e.PlayerId == playerId)
                            .ToListAsync()
                            .ConfigureAwait(false);
    }

    public Task DeleteAsync(IEnumerable<TeamSchemeFormationPlayer> entities)
    {
        Context.Set<TeamSchemeFormationPlayer>().RemoveRange(entities);
        return Context.SaveChangesAsync();
    }
}