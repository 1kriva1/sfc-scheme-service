using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Features.Common.Models.Find;
using SFC.Scheme.Application.Features.Common.Models.Find.Paging;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team.Player;
using SFC.Scheme.Domain.Entities.Game.Team.Player;
using SFC.Scheme.Domain.Entities.Player;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Extensions;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Game.Team.Player;

public class GameTeamPlayerRepository(GameDbContext context)
    : Repository<GameTeamPlayer, GameDbContext, long>(context), IGameTeamPlayerRepository
{
    public override Task<PagedList<GameTeamPlayer>> FindAsync(FindParameters<GameTeamPlayer> parameters)
    {
        return Context.GameTeamPlayers
                      .ThanIncludeTeam()
                      .AsQueryable()
                      .PaginateAsync(parameters);
    }

    public Task<GameTeamPlayer?> GetByIdAsync(long gameId, long teamId, long playerId)
    {
        return Context.GameTeamPlayers
            .Include(p => p.GamePlayer)
            .Include(p => p.TeamPlayer)
            .FirstOrDefaultAsync(item =>
            item.GameTeam.GameId == gameId && item.GameTeam.TeamId == teamId &&
            ((item.GamePlayer != null && item.GamePlayer.PlayerId == playerId) || (item.TeamPlayer != null && item.TeamPlayer.PlayerId == playerId)));
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.GameTeamPlayers.AnyAsync(item => item.Id == id);
    }

    public Task<bool> AnyAsync(long gameId, long teamId, long playerId)
    {
        return Context.GameTeamPlayers
            .Include(p => p.GamePlayer)
            .Include(p => p.TeamPlayer)
            .AnyAsync(item =>
            item.GameTeam.GameId == gameId &&
            item.GameTeam.TeamId == teamId &&
            ((item.GamePlayer != null && item.GamePlayer.PlayerId == playerId) || (item.TeamPlayer != null && item.TeamPlayer.PlayerId == playerId)));
    }

    public Task<int> CountAsync(IEnumerable<long> ids)
    {
        return Context.GameTeamPlayers.CountAsync(item => ids.Contains(item.Id));
    }

    public async Task<GameTeamPlayer[]> AddRangeIfNotExistsAsync(params GameTeamPlayer[] entities)
    {
        await Context.Set<GameTeamPlayer>().AddRangeIfNotExistsAsync<GameTeamPlayer, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }
}