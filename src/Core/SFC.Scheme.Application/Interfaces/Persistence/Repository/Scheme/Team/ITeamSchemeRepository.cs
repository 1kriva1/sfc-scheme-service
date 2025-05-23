using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;
using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface ITeamSchemeRepository : IRepository<TeamScheme, ISchemeDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<IEnumerable<TeamScheme>> GetByUserIdsAsync(IEnumerable<Guid> userIds);

    Task<TeamScheme?> GetByIdAsync(long id, long teamId);

    Task<TeamScheme[]> AddRangeIfNotExistsAsync(params TeamScheme[] entities);
}