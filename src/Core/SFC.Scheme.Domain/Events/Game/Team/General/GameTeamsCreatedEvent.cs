using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Game.Team.General;

namespace SFC.Scheme.Domain.Events.Game.Team.General;
public class GameTeamsCreatedEvent(IEnumerable<GameTeam> gameTeams) : BaseEvent
{
    public IEnumerable<GameTeam> GameTeams { get; } = gameTeams;
}