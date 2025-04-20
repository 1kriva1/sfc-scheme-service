using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Events.Player;
public class PlayersCreatedEvent(IEnumerable<PlayerEntity> players) : BaseEvent
{
    public IEnumerable<PlayerEntity> Players { get; } = players;
}