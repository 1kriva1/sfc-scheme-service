using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Game.Team;
public class GameTeamSchemeFormationPlayerPosition : BaseEntity<long>
{
    public int? Index { get; set; }

    public int? X { get; set; }

    public int? Y { get; set; }

    public FormationPositionEnum FormationPositionId { get; set; }

    public GameTeamSchemeFormationPlayer Player { get; set; } = default!;
}