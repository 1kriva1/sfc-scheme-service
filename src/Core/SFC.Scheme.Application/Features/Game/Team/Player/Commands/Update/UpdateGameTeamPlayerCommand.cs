using SFC.Scheme.Application.Common.Dto.Game.Team.Player;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Update;
public class UpdateGameTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGameTeamPlayer; }

    public required GameTeamPlayerDto GameTeamPlayer { get; set; }
}