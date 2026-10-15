using SFC.Scheme.Application.Common.Dto.Game.Player;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Player.Commands.Creates;
public class CreatesGamePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGamePlayers; }

    public IEnumerable<GamePlayerDto> GamePlayers { get; set; } = null!;
}