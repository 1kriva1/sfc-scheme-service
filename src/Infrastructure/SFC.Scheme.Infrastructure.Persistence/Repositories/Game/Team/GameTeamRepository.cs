using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Features.Common.Models.Find;
using SFC.Scheme.Application.Features.Common.Models.Find.Paging;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team;
using SFC.Scheme.Domain.Entities.Game.Team;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Extensions;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Game.Team;
public class GameTeamRepository(GameDbContext context)
    : Repository<GameTeam, GameDbContext, long>(context), IGameTeamRepository
{
    public override Task<PagedList<GameTeam>> FindAsync(FindParameters<GameTeam> parameters)
    {
        return Context.GameTeams
                      .ThanIncludeTeam()
                      .AsQueryable()
                      .PaginateAsync(parameters);
    }

    public Task<GameTeam?> GetByIdAsync(long gameId, long teamId)
    {
        return Context.GameTeams.FirstOrDefaultAsync(item => item.GameId == gameId && item.Team.Id == teamId);
    }

    public Task<bool> AnyAsync(long id)
    {
        return Context.GameTeams.AnyAsync(item => item.Id == id);
    }

    public Task<bool> AnyAsync(long gameId, long teamId)
    {
        return Context.GameTeams.AnyAsync(item => item.GameId == gameId && item.Team.Id == teamId);
    }

    public Task<bool> AnyAsync(long gameId, long teamId, GameTeamStatusEnum status)
    {
        return Context.GameTeams.AnyAsync(GameTeam =>
            GameTeam.GameId == gameId &&
            GameTeam.StatusId == status &&
            GameTeam.Team.Id == teamId);
    }

    public async Task<GameTeam[]> AddRangeIfNotExistsAsync(params GameTeam[] entities)
    {
        await Context.Set<GameTeam>().AddRangeIfNotExistsAsync<GameTeam, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }
}