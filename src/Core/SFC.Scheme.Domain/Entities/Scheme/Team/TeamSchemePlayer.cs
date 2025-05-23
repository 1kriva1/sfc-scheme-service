using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Scheme.Team;
public class TeamSchemePlayer : BaseEntity<long>, IPlayerEntity
{
    public long PlayerId { get; set; }

    public long TeamSchemeId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public TeamSchemePlayerPosition Position { get; set; } = default!;
}