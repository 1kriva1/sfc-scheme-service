using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Scheme.Game.Team;
public class GameTeamSchemeFormationPlayer : BaseEntity<long>, IPlayerEntity
{
    public long GameTeamSchemeFormationId { get; set; }

    public GameTeamSchemeFormation Formation { get; set; } = default!;

    public long PlayerId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public GameTeamSchemeFormationPlayerPosition Position { get; set; } = default!;
}