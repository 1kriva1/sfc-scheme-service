using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Create;
public class CreateGameTeamSchemeCommand : Request<CreateGameTeamSchemeViewModel>
{
    public override RequestId RequestId { get => RequestId.CreateGameTeamScheme; }

    public CreateGameTeamSchemeDto Scheme { get; set; } = null!;

    public CreateGameTeamSchemeCommand SetTeamId(long teamId)
    {
        this.Scheme.TeamId = teamId;
        return this;
    }

    public CreateGameTeamSchemeCommand SetGameId(long gameId)
    {
        this.Scheme.GameId = gameId;
        return this;
    }
}