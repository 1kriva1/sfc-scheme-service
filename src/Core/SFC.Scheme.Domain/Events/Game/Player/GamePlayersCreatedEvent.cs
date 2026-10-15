using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Game.Player;

namespace SFC.Scheme.Domain.Events.Game.Player;
public class GamePlayersCreatedEvent(IEnumerable<GamePlayer> gamePlayes) : BaseEvent
{
    public IEnumerable<GamePlayer> GamePlayers { get; } = gamePlayes;
}