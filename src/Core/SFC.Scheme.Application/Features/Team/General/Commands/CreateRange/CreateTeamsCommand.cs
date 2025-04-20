using SFC.Scheme.Application.Common.Dto.Team.General;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Team.General.Commands.CreateRange;
public class CreateTeamsCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeams; }

    public IEnumerable<TeamDto> Teams { get; set; } = null!;
}