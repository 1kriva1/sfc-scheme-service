using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find.Filters;

/// <summary>
/// Get team schemes **players stats filter** model.
/// </summary>
public class GetGameTeamSchemesPlayersStatsFilterModel : IMapTo<GetGameTeamSchemesPlayersStatsFilterDto>
{
    /// <summary>
    /// Filter by total rating of scheme players.
    /// </summary>
    public RangeLimitModel<short?>? Total { get; set; }
}