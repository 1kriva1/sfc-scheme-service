using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme;
using SFC.Scheme.Infrastructure.Persistence.Contexts;
using SFC.Scheme.Infrastructure.Persistence.Extensions;
using SFC.Scheme.Infrastructure.Persistence.Repositories.Common;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme;
public class SchemeRepository(SchemeDbContext context)
    : Repository<SchemeEntity, SchemeDbContext, long>(context), ISchemeRepository
{
    #region Public

    public Task<bool> AnyAsync(long id)
    {
        return Context.Schemes.AnyAsync(u => u.Id == id);
    }

    public Task<bool> AnyAsync(long id, Guid userId)
    {
        return Context.Schemes.AnyAsync(u => u.Id == id && u.UserId == userId);
    }

    public async Task<SchemeEntity[]> AddRangeIfNotExistsAsync(params SchemeEntity[] entities)
    {
        await Context.Set<SchemeEntity>().AddRangeIfNotExistsAsync<SchemeEntity, long>(entities).ConfigureAwait(true);

        await Context.SaveChangesAsync().ConfigureAwait(true);

        return entities;
    }

    #endregion Public

    #region Ovveride

    #endregion Ovveride
}