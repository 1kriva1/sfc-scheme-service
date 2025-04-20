using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Player.Commands.CreateRange;
public class CreatePlayersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreatePlayers; }

    public IEnumerable<PlayerDto> Players { get; set; } = null!;
}