using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Creates;
public class CreatesGameTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGameTeamPlayers; }

    public IEnumerable<CreatesGameTeamPlayerDto> GameTeamPlayers { get; set; } = null!;
}