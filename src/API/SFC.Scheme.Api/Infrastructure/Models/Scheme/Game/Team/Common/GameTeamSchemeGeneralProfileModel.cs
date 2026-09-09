using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;

/// <summary>
/// Team's scheme **general** profile model.
/// </summary>
public class GameTeamSchemeGeneralProfileModel : IMapFromReverse<GameTeamSchemeGeneralProfileDto>
{
    /// <summary>
    /// Name.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Comment or some description about scheme.
    /// </summary>
    public string? Comment { get; set; }
}