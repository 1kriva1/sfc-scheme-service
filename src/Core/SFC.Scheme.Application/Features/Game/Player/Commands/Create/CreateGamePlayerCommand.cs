using SFC.Scheme.Application.Common.Dto.Game.Player;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Player.Commands.Create;
public class CreateGamePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGamePlayer; }

    public required GamePlayerDto GamePlayer { get; set; }
}