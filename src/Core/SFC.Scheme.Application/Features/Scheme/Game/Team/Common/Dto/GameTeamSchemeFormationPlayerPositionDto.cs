using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;
public class GameTeamSchemeFormationPlayerPositionDto : IMapToReverse<GameTeamSchemeFormationPlayerPosition>
{
    public int? Index { get; set; }

    public int? X { get; set; }

    public int? Y { get; set; }

    public FormationPositionEnum FormationPositionId { get; set; }
}