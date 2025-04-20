using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Team.Data.Common.Dto;

namespace SFC.Scheme.Application.Features.Team.Data.Commands.Reset;
public class ResetTeamDataCommand : Request
{
    public override RequestId RequestId { get => RequestId.ResetTeamData; }

    public IEnumerable<TeamPlayerStatusDto> TeamPlayerStatuses { get; init; } = [];
}