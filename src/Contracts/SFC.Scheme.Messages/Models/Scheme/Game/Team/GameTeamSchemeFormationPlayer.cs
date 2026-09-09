namespace SFC.Scheme.Messages.Models.Scheme.Game.Team;
public class GameTeamSchemeFormationPlayer
{
    public long PlayerId { get; set; }

    public required GameTeamSchemeFormationPlayerPosition Position { get; set; }
}