using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find.Filters;

/// <summary>
/// Get team schemes **profile filter** model.
/// </summary>
public class GetGameTeamSchemesProfileFilterModel : IMapTo<GetGameTeamSchemesProfileFilterDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public GetGameTeamSchemesGeneralProfileFilterModel? General { get; set; }
}