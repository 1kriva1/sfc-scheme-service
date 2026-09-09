using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find.Filters;

/// <summary>
/// Get team schemes **formation filter** model.
/// </summary>
public class GetGameTeamSchemesFormationFilterModel : IMapTo<GetGameTeamSchemesFormationFilterDto>
{
    /// <summary>
    /// What **formation** scheme use.
    /// </summary>
    public int? Formation { get; set; }

    /// <summary>
    /// Scheme formation players.
    /// </summary>
    public GetGameTeamSchemesFormationPlayersFilterModel? Players { get; set; }
}