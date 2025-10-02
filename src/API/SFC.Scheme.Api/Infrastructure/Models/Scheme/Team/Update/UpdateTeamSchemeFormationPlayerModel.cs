using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Update;

/// <summary>
/// Team's scheme **player** model.
/// </summary>
public class UpdateTeamSchemeFormationPlayerModel : IMapTo<TeamSchemeFormationPlayerDto>
{
    /// <summary>
    /// Player unique identifier.
    /// </summary>
    public long PlayerId { get; set; }

    /// <summary>
    /// Player's position in formation.
    /// </summary>
    public TeamSchemeFormationPlayerPositionModel Position { get; set; } = default!;
}