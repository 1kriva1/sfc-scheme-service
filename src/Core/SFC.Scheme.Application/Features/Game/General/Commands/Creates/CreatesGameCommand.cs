using SFC.Scheme.Application.Common.Dto.Game.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.General.Commands.Creates;
public class CreatesGameCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGames; }

    public IEnumerable<GameDto> Games { get; set; } = null!;
}