using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find.Filters;

/// <summary>
/// Get team schemes filter model.
/// </summary>
public class GetGameTeamSchemesFilterModel : IMapTo<GetGameTeamSchemesFilterDto>
{
    /// <summary>
    /// Team scheme profile filter.
    /// </summary>
    public GetGameTeamSchemesProfileFilterModel? Profile { get; set; }

    /// <summary>
    /// Team scheme formation filter.
    /// </summary>
    public GetGameTeamSchemesFormationFilterModel? Formation { get; set; }
}