using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Domain.Events.Game.Team.Player;
public class GameTeamPlayersCreatedEvent(IEnumerable<GameTeamPlayer> gameTeamPlayers) : BaseEvent
{
    public IEnumerable<GameTeamPlayer> GameTeams { get; } = gameTeamPlayers;
}