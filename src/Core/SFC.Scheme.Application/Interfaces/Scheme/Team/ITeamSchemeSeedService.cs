using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Interfaces.Scheme.Team;
public interface ITeamSchemeSeedService
{
    Task<IEnumerable<TeamScheme>> GetSeedTeamSchemesAsync();

    Task SeedTeamSchemesAsync(CancellationToken cancellationToken = default);
}