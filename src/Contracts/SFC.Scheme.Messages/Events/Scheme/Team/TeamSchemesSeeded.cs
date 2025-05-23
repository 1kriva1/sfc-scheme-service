using SFC.Scheme.Messages.Models.Scheme.Team;

namespace SFC.Scheme.Messages.Events.Scheme.Team;
public class TeamSchemesSeeded
{
    public IEnumerable<TeamScheme> Schemes { get; init; } = [];
}