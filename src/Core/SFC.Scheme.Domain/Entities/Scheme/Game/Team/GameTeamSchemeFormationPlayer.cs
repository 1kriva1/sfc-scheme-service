using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Domain.Entities.Scheme.Game.Team;
public class GameTeamSchemeFormationPlayer : BaseEntity<long>
{
    public long GameTeamSchemeFormationId { get; set; }

    public GameTeamSchemeFormation Formation { get; set; } = default!;

    public long GameTeamPlayerId { get; set; }

    public GameTeamPlayer GameTeamPlayer { get; set; } = default!;

    public GameTeamSchemeFormationPlayerPosition Position { get; set; } = default!;
}