using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;
using SFC.Scheme.Domain.Entities.Game.Team;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Game.Team;
public interface IGameTeamRepository : IRepository<GameTeam, IGameDbContext, long>
{
    Task<bool> AnyAsync(long id);

    Task<bool> AnyAsync(long gameId, long teamId);

    Task<bool> AnyAsync(long gameId, long teamId, GameTeamStatusEnum status);

    Task<GameTeam?> GetByIdAsync(long gameId, long teamId);

    Task<GameTeam[]> AddRangeIfNotExistsAsync(params GameTeam[] entities);
}