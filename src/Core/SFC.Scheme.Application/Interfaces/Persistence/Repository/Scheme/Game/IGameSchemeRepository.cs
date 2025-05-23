using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;
using SFC.Scheme.Domain.Entities.Scheme.Game;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game;

/// <summary>
/// Repository for core entity of the service.
/// </summary>
public interface IGameSchemeRepository : IRepository<GameScheme, ISchemeDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long id, Guid userId);

    Task<GameScheme[]> AddRangeIfNotExistsAsync(params GameScheme[] entities);
}