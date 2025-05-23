using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Update;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Find;
public class GetTeamSchemesQuery : BasePaginationRequest<GetTeamSchemesViewModel, GetTeamSchemesFilterDto>
{
    public override RequestId RequestId { get => RequestId.GetTeamSchemes; }

    public GetTeamSchemesQuery SetTeamId(long id)
    {
        if (this.Filter is not null)
        {
            this.Filter.TeamId = id;

            return this;
        }

        this.Filter = new GetTeamSchemesFilterDto
        {
            TeamId = id
        };

        return this;
    }
}