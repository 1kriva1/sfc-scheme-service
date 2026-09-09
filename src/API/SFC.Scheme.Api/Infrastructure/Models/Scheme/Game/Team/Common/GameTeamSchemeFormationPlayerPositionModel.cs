using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;

/// <summary>
/// Team's scheme player **position** model.
/// </summary>
public class GameTeamSchemeFormationPlayerPositionModel : IMapFromReverse<GameTeamSchemeFormationPlayerPositionDto>
{
    /// <summary>
    /// Index in formation line.
    /// </summary>
    public int? Index { get; set; }

    /// <summary>
    /// X coordinate. 
    /// Exist in case scheme type is custom.
    /// </summary>
    public int? X { get; set; }

    /// <summary>
    /// Y coordinate. 
    /// Exist in case scheme type is custom.
    /// </summary>
    public int? Y { get; set; }

    /// <summary>
    /// Formation position unique identifier.
    /// </summary>
    public int FormationPositionId { get; set; }
}