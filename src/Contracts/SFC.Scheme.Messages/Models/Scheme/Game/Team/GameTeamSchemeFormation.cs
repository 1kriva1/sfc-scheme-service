namespace SFC.Scheme.Messages.Models.Scheme.Game.Team;
public class GameTeamSchemeFormation
{
    public int TypeId { get; set; }

    public int FormationId { get; set; }

    public IEnumerable<GameTeamSchemeFormationPlayer> Players { get; init; } = [];
}