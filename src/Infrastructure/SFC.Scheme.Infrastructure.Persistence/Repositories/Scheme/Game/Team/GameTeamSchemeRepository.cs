using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Features.Common.Models.Find;
using SFC.Scheme.Application.Features.Common.Models.Find.Paging;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Extensions;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Game.Team;
public class GameTeamSchemeRepository(SchemeDbContext context)
    : Repository<GameTeamScheme, SchemeDbContext, long>(context), IGameTeamSchemeRepository
{
    #region Public

    public Task<bool> AnyAsync(long id)
    {
        return Context.GameTeamSchemes.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.GameTeamSchemes.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public async Task<IEnumerable<GameTeamScheme>> GetByUserIdsAsync(IEnumerable<Guid> userIds)
    {
        return await Context.GameTeamSchemes
                            .Include(p => p.GeneralProfile)
                            .Include(p => p.Formation).ThenInclude(p => p.Players).ThenInclude(p => p.Player)
                            .Include(p => p.Formation).ThenInclude(p => p.Players).ThenInclude(p => p.Position)
                            .Where(team => userIds.Contains(team.UserId))
                            .ToListAsync()
                            .ConfigureAwait(true);

    }

    public Task<GameTeamScheme?> GetByIdAsync(long id, long gameId, long teamId)
    {
        return Context.GameTeamSchemes
                      .ThanIncludePlayer()
                      .ThanIncludeTeam()
                      .Include(p => p.GeneralProfile)
                      .Include(p => p.Formation).ThenInclude(p => p.Players).ThenInclude(p => p.Position)
                      .FirstOrDefaultAsync(p => p.Id == id && p.GameId == gameId && p.TeamId == teamId);
    }

    public async Task<GameTeamScheme[]> AddRangeIfNotExistsAsync(params GameTeamScheme[] entities)
    {
        await Context.Set<GameTeamScheme>().AddRangeIfNotExistsAsync<GameTeamScheme, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    public override Task<GameTeamScheme?> GetByIdAsync(long id)
    {
        return Context.GameTeamSchemes
                      .ThanIncludeGame()
                      .ThanIncludePlayer()
                      .ThanIncludeTeam()
                      .Include(p => p.GeneralProfile)
                      .Include(p => p.Formation).ThenInclude(p => p.Players).ThenInclude(p => p.Position)
                      .FirstOrDefaultAsync(p => p.Id == id);

    }

    public override Task<PagedList<GameTeamScheme>> FindAsync(FindParameters<GameTeamScheme> parameters)
    {
        return Context.GameTeamSchemes
                      .ThanIncludeGame()
                      .ThanIncludePlayer()
                      .ThanIncludeTeam()
                      .Include(p => p.GeneralProfile)
                      .Include(p => p.Formation).ThenInclude(p => p.Players).ThenInclude(p => p.Position)
                      .AsQueryable()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}