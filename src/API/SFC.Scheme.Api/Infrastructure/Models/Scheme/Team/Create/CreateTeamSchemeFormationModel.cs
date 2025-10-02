using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;

using TeamSchemeFormationDto = SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto.TeamSchemeFormationDto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Create;

/// <summary>
/// Team's scheme create **player** model.
/// </summary>
public class CreateTeamSchemeFormationModel : IMapTo<TeamSchemeFormationDto>
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
    public IEnumerable<CreateTeamSchemeFormationPlayerModel> Players { get; set; } = [];
}