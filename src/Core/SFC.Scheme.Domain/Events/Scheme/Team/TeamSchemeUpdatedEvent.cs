using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Domain.Events.Scheme.Team;
public class TeamSchemeUpdatedEvent(TeamScheme entity) : BaseEvent
{
    public TeamScheme Scheme { get; } = entity;
}