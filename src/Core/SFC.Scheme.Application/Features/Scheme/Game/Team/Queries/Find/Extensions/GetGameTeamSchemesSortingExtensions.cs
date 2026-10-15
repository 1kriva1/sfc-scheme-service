using System.Linq.Expressions;

using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Application.Features.Common.Extensions;
using SFC.Scheme.Application.Features.Common.Models.Find.Sorting;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;
using SFC.Scheme.Domain.Entities.Game.Team.Player;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Extensions;
public static class GetGameTeamSchemesSortingExtensions
{
    public static IEnumerable<Sorting<GameTeamScheme, dynamic>> BuildGameTeamSchemeSearchSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting(BuildExpression);

    private static Expression<Func<GameTeamScheme, dynamic>>? BuildExpression(string name)
    {
        return name switch
        {
            nameof(GetGameTeamSchemesGeneralProfileFilterDto.Name) => p => p.GeneralProfile.Name,
            nameof(GetGameTeamSchemesPlayersStatsFilterDto.Total) => p => p.Formation.Players.SelectMany(s => GetPlayer(s.GameTeamPlayer).Stats).Sum(m => m.Value),
            _ => null
        };
    }

    private static PlayerEntity GetPlayer(GameTeamPlayer gameTeamPlayer) => (gameTeamPlayer.GamePlayer?.Player ?? gameTeamPlayer.TeamPlayer?.Player)!;
}