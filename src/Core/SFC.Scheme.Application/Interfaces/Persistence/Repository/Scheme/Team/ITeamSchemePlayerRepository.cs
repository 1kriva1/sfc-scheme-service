using SFC.Scheme.Application.Interfaces.Persistence.Context;
using SFC.Scheme.Application.Interfaces.Persistence.Repository.Common;
using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Interfaces.Persistence.Repository.Scheme.Team;

public interface ITeamSchemePlayerRepository : IRepository<TeamSchemeFormationPlayer, ISchemeDbContext, long>
{
    Task<IReadOnlyList<TeamSchemeFormationPlayer>> ListAllAsync(long teamId, long playerId);

    Task DeleteAsync(IEnumerable<TeamSchemeFormationPlayer> entities);
}