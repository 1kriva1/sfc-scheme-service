using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find.Filters;

/// <summary>
/// Get team schemes **players stats filter** model.
/// </summary>
public class GetTeamSchemesPlayersStatsFilterModel : IMapTo<GetTeamSchemesPlayersStatsFilterDto>
{
    /// <summary>
    /// Filter by total rating of scheme players.
    /// </summary>
    public RangeLimitModel<short?>? Total { get; set; }
}