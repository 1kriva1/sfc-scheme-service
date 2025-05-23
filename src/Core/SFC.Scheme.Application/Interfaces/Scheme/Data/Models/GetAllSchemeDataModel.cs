using SFC.Scheme.Domain.Entities.Scheme.Data;

namespace SFC.Scheme.Application.Interfaces.Scheme.Data.Models;
public record GetAllSchemeDataModel
{
    public IEnumerable<Formation> Formations { get; init; } = [];

    public IEnumerable<FormationPosition> FormationPositions { get; init; } = [];

    public IEnumerable<SchemeType> SchemeTypes { get; init; } = [];
}