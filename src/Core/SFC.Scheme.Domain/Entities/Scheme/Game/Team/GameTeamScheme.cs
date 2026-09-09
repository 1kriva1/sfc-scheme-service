using SFC.Scheme.Domain.Common;
using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Scheme.Game.Team;
public class GameTeamScheme : BaseAuditableEntity<long>, IUserEntity, ITeamEntity, IGameEntity
{
    public Guid UserId { get; set; }

    public long TeamId { get; set; }

    public TeamEntity Team { get; set; } = default!;

    public long GameId { get; set; }

    public GameEntity Game { get; set; } = default!;

    public GameTeamSchemeGeneralProfile GeneralProfile { get; set; } = default!;

    public GameTeamSchemeFormation Formation { get; set; } = default!;
}