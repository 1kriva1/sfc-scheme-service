using SFC.Scheme.Application.Common.Dto.Game.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.General.Commands.Update;
public class UpdateGameCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGame; }

    public GameDto Game { get; set; } = null!;
}