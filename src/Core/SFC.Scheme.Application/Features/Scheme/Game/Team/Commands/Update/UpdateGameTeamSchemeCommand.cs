using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Update;
public class UpdateGameTeamSchemeCommand : Request
{
    public override RequestId RequestId { get => RequestId.UpdateGameTeamScheme; }

    public required UpdateGameTeamSchemeDto Scheme { get; set; }

    public UpdateGameTeamSchemeCommand SetSchemeId(long id)
    {
        this.Scheme.Id = id;
        return this;
    }

    public UpdateGameTeamSchemeCommand SetTeamId(long id)
    {
        this.Scheme.TeamId = id;
        return this;
    }

    public UpdateGameTeamSchemeCommand SetGameId(long id)
    {
        this.Scheme.GameId = id;
        return this;
    }
}