using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Game.Team;

public class GameTeam : BaseAuditableReferenceEntity<long>, ITeamEntity, IUserEntity, IGameEntity
{
    public long GameId { get; set; }

    public long TeamId { get; set; }

    public Guid UserId { get; set; }

    public GameTeamStatusEnum StatusId { get; set; }

    public GameTeamIndexEnum? Index { get; set; }

    public GameEntity Game { get; set; } = default!;

    public TeamEntity Team { get; set; } = default!;
}