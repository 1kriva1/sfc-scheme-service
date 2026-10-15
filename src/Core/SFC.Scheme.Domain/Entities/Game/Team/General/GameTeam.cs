using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Domain.Entities.Game.Team.General;

public class GameTeam : BaseAuditableReferenceEntity<long>, ITeamEntity, IUserEntity, IGameEntity
{
    public long GameId { get; set; }

    public long TeamId { get; set; }

    public Guid UserId { get; set; }

    public GameTeamStatusEnum StatusId { get; set; }

    public GameTeamIndexEnum? Index { get; set; }

    public GameEntity Game { get; set; } = default!;

    public TeamEntity Team { get; set; } = default!;

    public ICollection<GameTeamPlayer> Players { get; } = [];
}