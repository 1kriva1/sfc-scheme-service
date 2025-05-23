using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;

/// <summary>
/// Team's scheme **general** profile model.
/// </summary>
public class TeamSchemeGeneralProfileModel : IMapFromReverse<TeamSchemeGeneralProfileDto>
{
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Comment or some description about scheme.
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// Type of scheme.
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// Formation type.
    /// </summary>
    public int FormationId { get; set; }
}