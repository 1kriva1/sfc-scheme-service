using SFC.Scheme.Messages.Models.Scheme.Game.Team;

namespace SFC.Scheme.Messages.Events.Scheme.Game.Team;
public class GameTeamSchemeUpdated
{
    public required GameTeamScheme Scheme { get; set; }
}