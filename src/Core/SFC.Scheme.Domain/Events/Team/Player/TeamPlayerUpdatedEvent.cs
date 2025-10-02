using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Team.Player;

namespace SFC.Scheme.Domain.Events.Team.Player;
public class TeamPlayerUpdatedEvent(TeamPlayer teamPlayer) : BaseEvent
{
    public TeamPlayer TeamPlayer { get; } = teamPlayer;
}