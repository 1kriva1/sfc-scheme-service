namespace SFC.Scheme.Messages.Models.Scheme.Team;
public class TeamSchemeFormationPlayer
{
    public long PlayerId { get; set; }

    public required TeamSchemeFormationPlayerPosition Position { get; set; }
}