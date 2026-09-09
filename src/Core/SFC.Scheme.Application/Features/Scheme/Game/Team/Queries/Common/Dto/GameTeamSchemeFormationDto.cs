using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Common.Dto;
public class GameTeamSchemeFormationDto : IMapFromReverse<GameTeamSchemeFormation>
{
    public int TypeId { get; set; }

    public int FormationId { get; set; }

    public IEnumerable<GameTeamSchemeFormationPlayerDto> Players { get; set; } = [];
}