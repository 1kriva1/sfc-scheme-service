namespace SFC.Scheme.Messages.Models.Scheme.Team;
public class TeamSchemeFormation
{
    public int TypeId { get; set; }

    public int FormationId { get; set; }

    public IEnumerable<TeamSchemeFormationPlayer> Players { get; init; } = [];
}