namespace SFC.Scheme.Application.Interfaces.Player;
public interface IPlayerSeedService
{
    Task SendRequirePlayersSeedAsync(CancellationToken cancellationToken = default);
}