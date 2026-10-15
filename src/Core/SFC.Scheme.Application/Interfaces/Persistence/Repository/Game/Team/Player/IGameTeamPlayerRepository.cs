using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team.Player;
public interface IGameTeamPlayerRepository : IRepository<GameTeamPlayer, IGameDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long gameId, long teamId, long playerId);

    Task<int> CountAsync(IEnumerable<long> ids);

    Task<GameTeamPlayer?> GetByIdAsync(long gameId, long teamId, long playerId);

    Task<GameTeamPlayer[]> AddRangeIfNotExistsAsync(params GameTeamPlayer[] entities);
}