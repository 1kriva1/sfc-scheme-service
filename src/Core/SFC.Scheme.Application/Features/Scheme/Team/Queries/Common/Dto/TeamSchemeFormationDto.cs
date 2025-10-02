using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;
public class TeamSchemeFormationDto : IMapFromReverse<TeamSchemeFormation>
{
    public int TypeId { get; set; }

    public int FormationId { get; set; }

    public IEnumerable<TeamSchemeFormationPlayerDto> Players { get; set; } = [];
}