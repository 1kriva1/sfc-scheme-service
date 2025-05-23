using System.Linq.Expressions;

using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Application.Features.Common.Extensions;
using SFC.Scheme.Application.Features.Common.Models.Find.Sorting;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Extensions;
public static class GetTeamSchemesSortingExtensions
{
    public static IEnumerable<Sorting<TeamScheme, dynamic>> BuildSchemeSearchSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting(BuildExpression);

    private static Expression<Func<TeamScheme, dynamic>>? BuildExpression(string name)
    {
        return name switch
        {
            nameof(GetTeamSchemesGeneralProfileFilterDto.Name) => p => p.GeneralProfile.Name,
            nameof(GetTeamSchemesPlayersStatsFilterDto.Total) => p => p.Players.SelectMany(s => s.Player.Stats).Sum(m => m.Value),
            _ => null
        };
    }
}