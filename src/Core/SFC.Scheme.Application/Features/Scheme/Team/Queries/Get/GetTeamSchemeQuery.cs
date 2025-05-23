using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Get;

public class GetTeamSchemeQuery : Request<GetTeamSchemeViewModel>
{
    public override RequestId RequestId { get => RequestId.GetTeamScheme; }

    public long Id { get; set; }
}