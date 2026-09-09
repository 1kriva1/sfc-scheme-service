using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Events.Game.General;
public class GamesCreatedEvent(IEnumerable<GameEntity> games) : BaseEvent
{
    public IEnumerable<GameEntity> GameTeams { get; } = games;
}