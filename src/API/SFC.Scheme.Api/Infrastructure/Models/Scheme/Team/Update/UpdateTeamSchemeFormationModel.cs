using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Update;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;

using TeamSchemeFormationDto = SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto.TeamSchemeFormationDto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Create;

/// <summary>
/// Team's scheme update **player** model.
/// </summary>
public class UpdateTeamSchemeFormationModel : IMapTo<TeamSchemeFormationDto>
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
    public IEnumerable<UpdateTeamSchemeFormationPlayerModel> Players { get; set; } = [];
}