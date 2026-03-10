namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;
public class GetTeamSchemesFormationFilterDto
{
    public int? Formation { get; set; }

    public GetTeamSchemesPlayersFilterDto? Players { get; set; }
}