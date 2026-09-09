using SFC.Scheme.Api.Infrastructure.Models.Player;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;

/// <summary>
/// Team's scheme formation **player** model.
/// </summary>
public class GameTeamSchemeFormationPlayerModel : IMapFromReverse<GameTeamSchemeFormationPlayerDto>
{
    /// <summary>
    /// Player model.
    /// </summary>
    public required PlayerModel Player { get; set; }

    /// <summary>
    /// Player's position in formation.
    /// </summary>
    public required GameTeamSchemeFormationPlayerPositionModel Position { get; set; }
}