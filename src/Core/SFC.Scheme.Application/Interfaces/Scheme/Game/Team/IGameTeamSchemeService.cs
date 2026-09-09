using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Interfaces.Scheme.Game.Team;
public interface IGameTeamSchemeService
{
    Task NotifyGameTeamSchemeCreatedAsync(GameTeamScheme scheme, CancellationToken cancellationToken = default);

    Task NotifyGameTeamSchemeUpdatedAsync(GameTeamScheme scheme, CancellationToken cancellationToken = default);
}