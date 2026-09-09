namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;
public class GetGameTeamSchemesFormationFilterDto
{
    public int? Formation { get; set; }

    public GetGameTeamSchemesPlayersFilterDto? Players { get; set; }
}