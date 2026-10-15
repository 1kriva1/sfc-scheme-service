using SFC.Scheme.Application.Common.Dto.Game.Team.Player;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Delete;
public class DeleteGameTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.DeleteGameTeamPlayer; }

    public required DeleteGameTeamPlayerDto GameTeamPlayer { get; set; }
}