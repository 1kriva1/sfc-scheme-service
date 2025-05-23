using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find.Filters;

/// <summary>
/// Get team schemes **players filter** model.
/// </summary>
public class GetTeamSchemesPlayersFilterModel : IMapTo<GetTeamSchemesPlayersFilterDto>
{
    /// <summary>
    /// Filter by stats of scheme players.
    /// </summary>
    public GetTeamSchemesPlayersStatsFilterModel? Stats { get; set; }
}