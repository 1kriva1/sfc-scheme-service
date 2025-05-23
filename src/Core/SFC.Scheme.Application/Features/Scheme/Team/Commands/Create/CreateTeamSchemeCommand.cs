using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;
public class CreateTeamSchemeCommand : Request<CreateTeamSchemeViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateTeamScheme; }

    public CreateTeamSchemeDto Scheme { get; set; } = null!;

    public CreateTeamSchemeCommand SetTeamId(long teamId)
    {
        this.Scheme.TeamId = teamId;
        return this;
    }
}