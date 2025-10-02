using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find.Filters;

/// <summary>
/// Get team schemes **formation filter** model.
/// </summary>
public class GetTeamSchemesFormationFilterModel : IMapTo<GetTeamSchemesFormationFilterDto>
{
    /// <summary>
    /// Scheme formation players.
    /// </summary>
    public GetTeamSchemesFormationPlayersFilterModel? Players { get; set; }
}