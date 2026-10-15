namespace SFC.Scheme.Application.Interfaces.Game.Team.Player;
public interface IGameTeamPlayerSeedService
{
    Task SendRequireGameTeamPlayersSeedAsync(CancellationToken cancellationToken = default);
}