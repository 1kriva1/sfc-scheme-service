using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Team;
public class TeamSchemeFormationPlayerPosition : BaseEntity<long>
{
    public int? Index { get; set; }

    public int? X { get; set; }

    public int? Y { get; set; }

    public FormationPositionEnum FormationPositionId { get; set; }

    public TeamSchemeFormationPlayer Player { get; set; } = default!;
}