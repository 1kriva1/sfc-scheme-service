using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Team.Player;

namespace SFC.Scheme.Domain.Events.Team.Player;
public class TeamPlayersCreatedEvent(IEnumerable<TeamPlayer> teamPlayers) : BaseEvent
{
    public IEnumerable<TeamPlayer> TeamPlayers { get; } = teamPlayers;
}