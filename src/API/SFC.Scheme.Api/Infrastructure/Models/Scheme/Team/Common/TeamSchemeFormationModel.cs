using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;

using TeamSchemeFormationDto = SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto.TeamSchemeFormationDto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;

/// <summary>
/// Team's scheme formation model.
/// </summary>
public class TeamSchemeFormationModel : IMapFromReverse<TeamSchemeFormationDto>
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
    public IEnumerable<TeamSchemeFormationPlayerModel> Players { get; set; } = [];
}