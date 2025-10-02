using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Team;
public class TeamSchemeFormation : BaseEntity<long>
{
    public FormationEnum FormationId { get; set; }

    public SchemeTypeEnum TypeId { get; set; }

    public ICollection<TeamSchemeFormationPlayer> Players { get; } = [];

    public TeamScheme Scheme { get; set; } = default!;
}