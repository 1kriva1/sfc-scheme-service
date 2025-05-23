using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find.Filters;

/// <summary>
/// Get team schemes **profile filter** model.
/// </summary>
public class GetTeamSchemesProfileFilterModel : IMapTo<GetTeamSchemesProfileFilterDto>
{
    /// <summary>
    /// General profile.
    /// </summary>
    public GetTeamSchemesGeneralProfileFilterModel? General { get; set; }
}