using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find;
public class GetGameTeamSchemesQuery : BasePaginationRequest<GetGameTeamSchemesViewModel, GetGameTeamSchemesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetGameTeamSchemes; }

    public GetGameTeamSchemesQuery SetTeamId(long id)
    {
        if (this.Filter is not null)
        {
            this.Filter.TeamId = id;

            return this;
        }

        this.Filter = new GetGameTeamSchemesFilterDto
        {
            TeamId = id
        };

        return this;
    }

    public GetGameTeamSchemesQuery SetGameId(long id)
    {
        if (this.Filter is not null)
        {
            this.Filter.GameId = id;

            return this;
        }

        this.Filter = new GetGameTeamSchemesFilterDto
        {
            GameId = id
        };

        return this;
    }
}