using SFC.Scheme.Messages.Commands.Common;
using SFC.Scheme.Messages.Models.Scheme.Game.Team;

namespace SFC.Scheme.Messages.Commands.Scheme.Game.Team;
public class SeedGameTeamSchemes : InitiatorCommand
{
    public IEnumerable<GameTeamScheme> Schemes { get; init; } = [];
}