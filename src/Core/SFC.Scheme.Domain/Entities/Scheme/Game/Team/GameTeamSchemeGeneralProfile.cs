using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Scheme.Game.Team;

public class GameTeamSchemeGeneralProfile : BaseEntity<long>
{
    public required string Name { get; set; }

    public string? Comment { get; set; }

    public GameTeamScheme Scheme { get; set; } = default!;
}