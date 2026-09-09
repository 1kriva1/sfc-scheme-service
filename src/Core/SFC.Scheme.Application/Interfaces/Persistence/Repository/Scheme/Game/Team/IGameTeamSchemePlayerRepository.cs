using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Game.Team;

public interface IGameTeamSchemePlayerRepository : IRepository<GameTeamSchemeFormationPlayer, ISchemeDbContext, long>
{
    Task<IReadOnlyList<GameTeamSchemeFormationPlayer>> ListAllAsync(long gameId, long teamId, long playerId);

    Task DeleteAsync(IEnumerable<GameTeamSchemeFormationPlayer> entities);
}