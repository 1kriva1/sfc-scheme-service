using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Game.Team;
public class GameTeamSchemeFormation : BaseEntity<long>
{
    public FormationEnum FormationId { get; set; }

    public SchemeTypeEnum TypeId { get; set; }

    public ICollection<GameTeamSchemeFormationPlayer> Players { get; } = [];

    public GameTeamScheme Scheme { get; set; } = default!;
}