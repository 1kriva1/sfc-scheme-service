using SFC.Scheme.Application.Common.Dto.Game.Team;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Team.Commands.Create;
public class CreateGameTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGameTeam; }

    public required GameTeamDto GameTeam { get; set; }
}