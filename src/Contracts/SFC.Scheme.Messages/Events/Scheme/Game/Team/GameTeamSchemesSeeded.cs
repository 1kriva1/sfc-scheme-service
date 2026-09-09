using SFC.Scheme.Messages.Models.Scheme.Game.Team;

namespace SFC.Scheme.Messages.Events.Scheme.Game.Team;
public class GameTeamSchemesSeeded
{
    public IEnumerable<GameTeamScheme> Schemes { get; init; } = [];
}