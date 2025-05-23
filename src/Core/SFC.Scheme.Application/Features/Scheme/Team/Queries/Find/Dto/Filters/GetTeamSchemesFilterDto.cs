namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;
public class GetTeamSchemesFilterDto
{
    public long TeamId { get; set; }

    public GetTeamSchemesProfileFilterDto? Profile { get; set; }

    public GetTeamSchemesPlayersFilterDto? Players { get; set; }
}