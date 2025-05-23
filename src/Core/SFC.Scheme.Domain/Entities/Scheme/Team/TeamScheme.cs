using SFC.Scheme.Domain.Common.Interfaces;

namespace SFC.Scheme.Domain.Entities.Scheme.Team;
public class TeamScheme : SchemeEntity, ITeamEntity
{
    public long TeamId { get; set; }

    public TeamEntity Team { get; set; } = default!;

    public TeamSchemeGeneralProfile GeneralProfile { get; set; } = default!;

    public ICollection<TeamSchemePlayer> Players { get; } = [];
}