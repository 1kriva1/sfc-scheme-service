namespace SFC.Scheme.Application.Interfaces.Game.Team.General;
public interface IGameTeamSeedService
{
    Task SendRequireGameTeamsSeedAsync(CancellationToken cancellationToken = default);
}