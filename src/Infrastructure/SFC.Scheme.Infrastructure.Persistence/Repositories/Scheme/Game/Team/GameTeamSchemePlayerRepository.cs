using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Game.Team;
public class GameTeamSchemePlayerRepository(SchemeDbContext context)
    : Repository<GameTeamSchemeFormationPlayer, SchemeDbContext, long>(context), IGameTeamSchemePlayerRepository
{
    public async Task<IReadOnlyList<GameTeamSchemeFormationPlayer>> ListAllAsync(long gameId, long teamId, long playerId)
    {
        return await Context.Set<GameTeamSchemeFormationPlayer>()
                            .Include(e => e.Formation).ThenInclude(e => e.Scheme)
                            .Where(e => e.Formation.Scheme.GameId == gameId && e.Formation.Scheme.TeamId == teamId && e.PlayerId == playerId)
                            .ToListAsync()
                            .ConfigureAwait(false);
    }

    public Task DeleteAsync(IEnumerable<GameTeamSchemeFormationPlayer> entities)
    {
        Context.Set<GameTeamSchemeFormationPlayer>().RemoveRange(entities);
        return Context.SaveChangesAsync();
    }
}