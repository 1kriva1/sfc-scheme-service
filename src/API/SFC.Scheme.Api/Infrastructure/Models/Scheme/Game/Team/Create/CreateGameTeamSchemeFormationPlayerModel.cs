using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Create;

/// <summary>
/// Team's scheme **player** model.
/// </summary>
public class CreateGameTeamSchemeFormationPlayerModel : IMapTo<GameTeamSchemeFormationPlayerDto>
{
    /// <summary>
    /// Player unique identifier.
    /// </summary>
    public long PlayerId { get; set; }

    /// <summary>
    /// Player's position in formation.
    /// </summary>
    public GameTeamSchemeFormationPlayerPositionModel Position { get; set; } = default!;
}