using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Features.Common.Models.Find;
using SFC.Scheme.Application.Features.Common.Models.Find.Paging;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;
using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Extensions;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Team;
public class TeamSchemeRepository(SchemeDbContext context)
    : Repository<TeamScheme, SchemeDbContext, long>(context), ITeamSchemeRepository
{
    #region Public

    public Task<bool> AnyAsync(long id)
    {
        return Context.TeamSchemes.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.TeamSchemes.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public async Task<IEnumerable<TeamScheme>> GetByUserIdsAsync(IEnumerable<Guid> userIds)
    {
        return await Context.TeamSchemes
                            .Include(p => p.GeneralProfile)
                            .Include(p => p.Players).ThenInclude(p => p.Player)
                            .Include(p => p.Players).ThenInclude(p => p.Position)
                            .Where(team => userIds.Contains(team.UserId))
                            .ToListAsync()
                            .ConfigureAwait(true);

    }

    public Task<TeamScheme?> GetByIdAsync(long id, long teamId)
    {
        return Context.TeamSchemes
                      .Include(p => p.GeneralProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.FootballProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability.Days)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Tags)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Stats).ThenInclude(x => x.Type)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Photo)
                      .Include(p => p.Players).ThenInclude(p => p.Position)
                      .FirstOrDefaultAsync(p => p.Id == id && p.TeamId == teamId);
    }

    public async Task<TeamScheme[]> AddRangeIfNotExistsAsync(params TeamScheme[] entities)
    {
        await Context.Set<TeamScheme>().AddRangeIfNotExistsAsync<TeamScheme, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    public override Task<TeamScheme?> GetByIdAsync(long id)
    {
        return Context.TeamSchemes
                      .Include(p => p.GeneralProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.FootballProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability.Days)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Tags)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Stats).ThenInclude(x => x.Type)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Photo)
                      .Include(p => p.Players).ThenInclude(p => p.Position)
                      .FirstOrDefaultAsync(p => p.Id == id);

    }

    public override Task<PagedList<TeamScheme>> FindAsync(FindParameters<TeamScheme> parameters)
    {
        return Context.TeamSchemes
                      .Include(p => p.GeneralProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.GeneralProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.FootballProfile)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Availability.Days)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Tags)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Stats).ThenInclude(x => x.Type)
                      .Include(p => p.Players).ThenInclude(p => p.Player).ThenInclude(p => p.Photo)
                      .Include(p => p.Players).ThenInclude(p => p.Position)
                      .AsQueryable()
                      .PaginateAsync(parameters);
    }

    #endregion Ovveride
}