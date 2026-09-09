using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Get;

public class GetGameTeamSchemeQuery : Request<GetGameTeamSchemeViewModel>
{
    public override RequestId RequestId { get => RequestId.GetGameTeamScheme; }

    public long Id { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }
}