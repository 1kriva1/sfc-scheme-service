using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Team.Data;

namespace SFC.Scheme.Domain.Events.Team.Data;

public class TeamDataResetedEvent(IEnumerable<TeamPlayerStatus> teamPlayerStatuses) : BaseEvent
{
    public IEnumerable<TeamPlayerStatus> TeamPlayerStatuses { get; } = teamPlayerStatuses;
}