using SFC.Scheme.Application.Common.Dto.Team.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Team.General.Commands.Create;
public class CreateTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeam; }

    public TeamDto Team { get; set; } = null!;
}