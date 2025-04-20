using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Player.Commands.Create;
public class CreatePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}