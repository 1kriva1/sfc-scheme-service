using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find.Filters;

/// <summary>
/// Get team schemes **general profile filter** model.
/// </summary>
public class GetTeamSchemesGeneralProfileFilterModel : IMapTo<GetTeamSchemesGeneralProfileFilterDto>
{
    /// <summary>
    /// Name of scheme.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Comment about scheme.
    /// </summary>
    public string? Comment { get; set; }
}