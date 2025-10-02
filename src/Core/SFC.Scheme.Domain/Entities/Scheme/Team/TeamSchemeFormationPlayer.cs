using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Scheme.Team;
public class TeamSchemeFormationPlayer : BaseEntity<long>, IPlayerEntity
{
    public long TeamSchemeFormationId { get; set; }

    public TeamSchemeFormation TeamSchemeFormation { get; set; } = default!;

    public long PlayerId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public TeamSchemeFormationPlayerPosition Position { get; set; } = default!;
}