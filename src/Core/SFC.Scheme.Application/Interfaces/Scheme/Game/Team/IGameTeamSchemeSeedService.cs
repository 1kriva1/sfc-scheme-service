using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Interfaces.Scheme.Game.Team;
public interface IGameTeamSchemeSeedService
{
    Task<IEnumerable<GameTeamScheme>> GetSeedGameTeamSchemesAsync();

    Task SeedGameTeamSchemesAsync(CancellationToken cancellationToken = default);
}