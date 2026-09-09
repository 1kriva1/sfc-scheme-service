using SFC.Scheme.Application.Common.Dto.Game.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.General.Commands.Create;
public class CreateGameCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGame; }

    public GameDto Game { get; set; } = null!;
}