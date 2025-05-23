using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find.Filters;

/// <summary>
/// Get team schemes filter model.
/// </summary>
public class GetTeamSchemesFilterModel : IMapTo<GetTeamSchemesFilterDto>
{
    /// <summary>
    /// Team scheme profile filter.
    /// </summary>
    public GetTeamSchemesProfileFilterModel? Profile { get; set; }

    /// <summary>
    /// Team scheme players filter.
    /// </summary>
    public GetTeamSchemesPlayersFilterModel? Players { get; set; }
}