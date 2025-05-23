using SFC.Scheme.Messages.Models.Data;

namespace SFC.Scheme.Messages.Events.Scheme.Data;
public record DataInitialized
{
    public IEnumerable<DataValue> SchemeTypes { get; init; } = [];

    public IEnumerable<FormationPositionDataValue> FormationPositions { get; init; } = [];

    public IEnumerable<FormationDataValue> Formations { get; init; } = [];
}