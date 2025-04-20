using SFC.Scheme.Messages.Models.Data;

namespace SFC.Scheme.Messages.Commands.Team.Data;
public record InitializeData
{
    public IEnumerable<DataValue> TeamPlayerStatuses { get; init; } = [];
}