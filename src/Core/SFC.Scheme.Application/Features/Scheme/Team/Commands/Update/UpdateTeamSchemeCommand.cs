using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Update;
public class UpdateTeamSchemeCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateTeamScheme; }

    public required UpdateTeamSchemeDto Scheme { get; set; }

    public UpdateTeamSchemeCommand SetSchemeId(long id)
    {
        this.Scheme.Id = id;
        return this;
    }

    public UpdateTeamSchemeCommand SetTeamId(long id)
    {
        this.Scheme.TeamId = id;
        return this;
    }
}