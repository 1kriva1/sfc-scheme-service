using SFC.Scheme.Messages.Models.Common;

namespace SFC.Scheme.Messages.Models.Scheme.Game.Team;
public class GameTeamScheme : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public required GameTeamSchemeProfile Profile { get; set; }

    public required GameTeamSchemeFormation Formation { get; set; }
}