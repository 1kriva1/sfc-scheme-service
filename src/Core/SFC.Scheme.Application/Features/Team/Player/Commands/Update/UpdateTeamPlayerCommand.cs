using SFC.Scheme.Application.Common.Dto.Team.Player;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Team.Player.Commands.Update;
public class UpdateTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateTeamPlayer; }

    public required TeamPlayerDto TeamPlayer { get; set; }
}