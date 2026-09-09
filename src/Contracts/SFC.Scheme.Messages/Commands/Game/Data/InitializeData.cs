using SFC.Scheme.Messages.Models.Data;

namespace SFC.Scheme.Messages.Commands.Game.Data;
public record InitializeData
{
    public IEnumerable<DataValue> GameStatuses { get; init; } = [];

    public IEnumerable<DataValue> GameTeamStatuses { get; init; } = [];

    public IEnumerable<DataValue> GameTeamIndexes { get; init; } = [];
}