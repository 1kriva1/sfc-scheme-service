using SFC.Scheme.Application.Common.Dto.Team.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Team.General.Commands.Update;
public class UpdateTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateTeam; }

    public TeamDto Team { get; set; } = null!;
}