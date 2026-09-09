using SFC.Scheme.Application.Features.Common.Dto.Common;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;
public class GetGameTeamSchemesPlayersStatsFilterDto
{
    public RangeLimitDto<short?>? Total { get; set; }
}