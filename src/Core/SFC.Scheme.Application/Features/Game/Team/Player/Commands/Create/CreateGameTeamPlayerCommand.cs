using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Create;
public class CreateGameTeamPlayerCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGameTeamPlayer; }

    public required CreateGameTeamPlayerDto GameTeamPlayer { get; set; }
}