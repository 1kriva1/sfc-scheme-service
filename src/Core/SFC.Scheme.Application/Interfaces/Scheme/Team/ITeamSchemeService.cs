using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Interfaces.Scheme.Team;
public interface ITeamSchemeService
{
    Task NotifyTeamSchemeCreatedAsync(TeamScheme scheme, CancellationToken cancellationToken = default);

    Task NotifyTeamSchemeUpdatedAsync(TeamScheme scheme, CancellationToken cancellationToken = default);
}