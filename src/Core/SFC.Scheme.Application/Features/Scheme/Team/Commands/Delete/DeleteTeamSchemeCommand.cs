using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Update;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Delete;
public class DeleteTeamSchemeCommand : Request
{
    public override RequestId RequestId { get => RequestId.DeleteTeamScheme; }

    public required DeleteTeamSchemeDto Scheme { get; set; }
}