using SFC.Scheme.Messages.Models.Scheme.Team;

namespace SFC.Scheme.Messages.Events.Scheme.Team;
public class TeamSchemeUpdated
{
    public required TeamScheme Scheme { get; set; }
}