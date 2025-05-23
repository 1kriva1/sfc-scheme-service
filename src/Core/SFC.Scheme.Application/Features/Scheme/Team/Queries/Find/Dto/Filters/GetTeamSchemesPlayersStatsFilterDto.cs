using SFC.Scheme.Application.Features.Common.Dto.Common;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;
public class GetTeamSchemesPlayersStatsFilterDto
{
    public RangeLimitDto<short?>? Total { get; set; }
}