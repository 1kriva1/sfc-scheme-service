using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Data;

namespace SFC.Scheme.Domain.Events.Data;

public class DataResetedEvent(
    IEnumerable<FootballPosition> footballPositions,
    GameStyle[] gameStyles,
    WorkingFoot[] workingFoots,
    StatType[] statTypes
    ) : BaseEvent
{
    public IEnumerable<FootballPosition> FootballPositions { get; } = footballPositions;

    public IEnumerable<GameStyle> GameStyles { get; } = gameStyles;

    public IEnumerable<WorkingFoot> WorkingFoots { get; } = workingFoots;

    public IEnumerable<StatType> StatTypes { get; } = statTypes;
}