using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IGameTeamSchemeRepository : IRepository<GameTeamScheme, ISchemeDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<IEnumerable<GameTeamScheme>> GetByUserIdsAsync(IEnumerable<Guid> userIds);

    Task<GameTeamScheme?> GetByIdAsync(long id, long gameId, long teamId);

    Task<GameTeamScheme[]> AddRangeIfNotExistsAsync(params GameTeamScheme[] entities);
}