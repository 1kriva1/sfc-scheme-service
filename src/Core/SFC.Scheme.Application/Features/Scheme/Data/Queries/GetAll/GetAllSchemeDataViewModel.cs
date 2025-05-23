using SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;

namespace SFC.Scheme.Application.Features.Scheme.Data.Queries.GetAll;

public record GetAllSchemeDataViewModel
{
    public IEnumerable<FormationDataValueDto> Formations { get; init; } = [];

    public IEnumerable<FormationPositionDataValueDto> FormationPositions { get; init; } = [];

    public IEnumerable<DataValueDto> SchemeTypes { get; init; } = [];
}