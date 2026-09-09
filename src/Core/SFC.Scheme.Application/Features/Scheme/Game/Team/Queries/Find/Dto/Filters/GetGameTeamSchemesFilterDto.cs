namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;
public class GetGameTeamSchemesFilterDto
{
    public long GameId { get; set; }

    public long TeamId { get; set; }

    public GetGameTeamSchemesProfileFilterDto? Profile { get; set; }

    public GetGameTeamSchemesFormationFilterDto? Formation { get; set; }
}