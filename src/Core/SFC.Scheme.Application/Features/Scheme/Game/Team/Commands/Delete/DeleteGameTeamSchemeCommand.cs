using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Delete;
public class DeleteGameTeamSchemeCommand : Request
{
    public override RequestId RequestId { get => RequestId.DeleteGameTeamScheme; }

    public required DeleteGameTeamSchemeDto Scheme { get; set; }
}