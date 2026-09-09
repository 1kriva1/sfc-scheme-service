using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find.Filters;

/// <summary>
/// Get team schemes **players filter** model.
/// </summary>
public class GetGameTeamSchemesFormationPlayersFilterModel : IMapTo<GetGameTeamSchemesPlayersFilterDto>
{
    /// <summary>
    /// Filter by stats of scheme players.
    /// </summary>
    public GetGameTeamSchemesPlayersStatsFilterModel? Stats { get; set; }
}