using SFC.Scheme.Application.Common.Dto.Team.Player;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Team.Player.Commands.Create;
public class CreateTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayer; }

    public required TeamPlayerDto TeamPlayer { get; set; }
}