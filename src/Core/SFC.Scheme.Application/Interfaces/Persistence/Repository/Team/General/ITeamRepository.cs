using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Team.General;
public interface ITeamRepository : IRepository<TeamEntity, ITeamDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<TeamEntity[]> AddRangeIfNotExistsAsync(params TeamEntity[] entities);
}