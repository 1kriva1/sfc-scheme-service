using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Player.Commands.Update;
public class UpdatePlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdatePlayer; }

    public PlayerDto Player { get; set; } = null!;
}