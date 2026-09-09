using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Create;

/// <summary>
/// Team's scheme create **player** model.
/// </summary>
public class CreateGameTeamSchemeFormationModel : IMapTo<GameTeamSchemeFormationDto>
{
    /// <summary>
    /// Type of scheme.
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// Formation type.
    /// </summary>
    public int FormationId { get; set; }

    /// <summary>
    /// Team's scheme formation players.
    /// </summary>
    public IEnumerable<CreateGameTeamSchemeFormationPlayerModel> Players { get; set; } = [];
}