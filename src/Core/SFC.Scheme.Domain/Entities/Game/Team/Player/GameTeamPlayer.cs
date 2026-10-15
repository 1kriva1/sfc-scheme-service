using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Game.Player;
using SFC.Scheme.Domain.Entities.Game.Team.General;
using SFC.Scheme.Domain.Entities.Team.Player;

namespace SFC.Scheme.Domain.Entities.Game.Team.Player;

public class GameTeamPlayer : BaseAuditableReferenceEntity<long>, IUserEntity
{
    public long GameTeamId { get; set; }

    public long? GamePlayerId { get; set; }

    public long? TeamPlayerId { get; set; }

    public Guid UserId { get; set; }

    public GameTeam GameTeam { get; set; } = default!;

    public GamePlayer? GamePlayer { get; set; }

    public TeamPlayer? TeamPlayer { get; set; }
}