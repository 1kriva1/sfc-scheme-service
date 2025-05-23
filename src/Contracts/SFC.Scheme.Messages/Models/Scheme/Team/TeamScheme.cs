using SFC.Scheme.Messages.Models.Common;

namespace SFC.Scheme.Messages.Models.Scheme.Team;
public class TeamScheme : Auditable
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long TeamId { get; set; }

    public required TeamSchemeProfile Profile { get; set; }

    public IEnumerable<TeamSchemePlayer> Players { get; init; } = [];
}