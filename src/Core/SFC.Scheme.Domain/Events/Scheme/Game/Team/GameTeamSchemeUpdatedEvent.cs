using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Domain.Events.Scheme.Game.Team;
public class GameTeamSchemeUpdatedEvent(GameTeamScheme entity) : BaseEvent
{
    public GameTeamScheme Scheme { get; } = entity;
}