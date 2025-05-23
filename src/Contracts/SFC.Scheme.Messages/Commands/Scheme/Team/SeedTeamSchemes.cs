using SFC.Scheme.Messages.Commands.Common;
using SFC.Scheme.Messages.Models.Scheme.Team;

namespace SFC.Scheme.Messages.Commands.Scheme.Team;
public class SeedTeamSchemes : InitiatorCommand
{
    public IEnumerable<TeamScheme> Schemes { get; init; } = [];
}