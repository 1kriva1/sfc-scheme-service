using Microsoft.EntityFrameworkCore;

using SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Data;
using SFC.Scheme.Domain.Entities.Scheme.Data;
using SFC.Scheme.Infrastructure.Persistence.Contexts;

namespace SFC.Scheme.Infrastructure.Persistence.Repositories.Scheme.Data;
public class FormationRepository(SchemeDbContext context)
    : SchemeDataRepository<Formation, FormationEnum>(context), IFormationRepository
{
    public override async Task<IReadOnlyList<Formation>> ListAllAsync()
    {
        return await Context.Formations
                            .Include(p => p.Values)
                            .ToListAsync()
                            .ConfigureAwait(false);
    }

    public override Task<Formation?> GetByIdAsync(FormationEnum id)
    {
        return Context.Formations
                      .Include(p => p.Values)
                      .FirstOrDefaultAsync(p => p.Id == id);
    }
}