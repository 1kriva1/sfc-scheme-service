namespace SFC.Scheme.Messages.Models.Scheme.Team;
public class TeamSchemeGeneralProfile
{
    public required string Name { get; set; }

    public string? Comment { get; set; }

    public int TypeId { get; set; }

    public int FormationId { get; set; }
}