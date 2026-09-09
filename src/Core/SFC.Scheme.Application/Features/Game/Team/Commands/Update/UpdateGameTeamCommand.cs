using SFC.Scheme.Application.Common.Dto.Game.Team;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Team.Commands.Update;
public class UpdateGameTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGameTeam; }

    public required GameTeamDto GameTeam { get; set; }
}