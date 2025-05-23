namespace SFC.Scheme.Messages.Models.Scheme.Team;
public class TeamSchemePlayer
{
    public long PlayerId { get; set; }

    public required TeamSchemePlayerPosition Position { get; set; }
}