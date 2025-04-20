using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Events.Team.General;
public class TeamsCreatedEvent(IEnumerable<TeamEntity> teams) : BaseEvent
{
    public IEnumerable<TeamEntity> Teams { get; } = teams;
}