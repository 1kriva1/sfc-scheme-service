using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Domain.Entities.Game.Player;

public class GamePlayer : BaseAuditableReferenceEntity<long>, IPlayerEntity, IUserEntity
{
    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public Guid UserId { get; set; }

    public GamePlayerStatusEnum StatusId { get; set; }

    public PlayerEntity Player { get; set; } = default!;

    public GameTeamPlayer? GameTeamPlayer { get; set; }
}