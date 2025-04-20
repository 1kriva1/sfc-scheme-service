using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Data;
using SFC.Scheme.Domain.Entities.Data;
using SFC.Scheme.Infrastructure.Persistence.Contexts;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Data;

public class StatTypeRepository(DataDbContext context)
    : DataRepository<StatType, StatTypeEnum>(context), IStatTypeRepository
{
    public virtual Task<int> CountAsync() => Context.StatTypes.CountAsync();

    public override async Task<IReadOnlyList<StatType>> ListAllAsync()
    {
        return await Context.StatTypes
                            .AsNoTracking()
                            .ToListAsync()
                            .ConfigureAwait(false);
    }
}