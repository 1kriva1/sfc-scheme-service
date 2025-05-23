using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game;
using SFC.Scheme.Domain.Entities.Scheme.Game;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Extensions;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Game;
public class GameSchemeRepository(SchemeDbContext context)
    : Repository<GameScheme, SchemeDbContext, long>(context), IGameSchemeRepository
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

    public async Task<GameScheme[]> AddRangeIfNotExistsAsync(params GameScheme[] entities)
    {
        await Context.Set<GameScheme>().AddRangeIfNotExistsAsync<GameScheme, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    #endregion Ovveride
}