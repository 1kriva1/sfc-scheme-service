using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
public class TeamSchemePlayerPositionDto : IMapToReverse<TeamSchemePlayerPosition>
{
    public int? Index { get; set; }

    public int? X { get; set; }

    public int? Y { get; set; }

    public FormationPositionEnum FormationPositionId { get; set; }
}