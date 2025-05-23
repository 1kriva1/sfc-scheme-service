using System.Linq.Expressions;

using SFC.Scheme.Application.Common.Constants;
using SFC.Scheme.Application.Features.Common.Constants;
using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Application.Features.Common.Models.Find.Filters;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Extensions;
public static class GetTeamSchemesFiltersExtensions
{
    public static IEnumerable<Filter<TeamScheme>> BuildSearchFilters(this GetTeamSchemesFilterDto filter)
    {
        return [
            new()
            {
                Condition = true,
                Expression = scheme => scheme.TeamId == filter!.TeamId
            },
            new()
            {
                Condition = !string.IsNullOrEmpty(filter?.Profile?.General?.Name),
                Expression = scheme => scheme.GeneralProfile.Name.Contains(filter!.Profile!.General!.Name!)
            },
            new()
            {
                Condition = !string.IsNullOrEmpty(filter?.Profile?.General?.Comment),
                Expression = scheme => string.IsNullOrEmpty(scheme.GeneralProfile.Comment) || scheme.GeneralProfile.Comment.Contains(filter!.Profile!.General!.Comment!)
            },
            new()
            {
                Condition = BuildLimitFromCondition(filter?.Players?.Stats?.Total, ValidationConstants.RangeLimit),
                Expression = FilterByPlayersStats(filter?.Players?.Stats?.Total?.From, null)
            },
            new()
            {
                Condition = BuildLimitToCondition(filter?.Players?.Stats?.Total, ValidationConstants.RangeLimit),
                Expression = FilterByPlayersStats(null, filter?.Players?.Stats?.Total?.To)
            }
        ];
    }

    private static bool BuildLimitFromCondition(RangeLimitDto<short?>? limit, Tuple<int, int> rangeLimit)
    {
        return (limit?.From.HasValue ?? false)
            && !(limit.From == rangeLimit.Item1 && limit.To == rangeLimit.Item2);
    }

    private static bool BuildLimitToCondition(RangeLimitDto<short?>? limit, Tuple<int, int> rangeLimit)
    {
        return (limit?.To.HasValue ?? false)
            && !(limit.From == rangeLimit.Item1 && limit.To == rangeLimit.Item2);
    }

    public static Expression<Func<TeamScheme, bool>> FilterByPlayersStats(short? from, short? to)
    {
        if (from.HasValue)
        {
            return scheme => ((int)Math.Ceiling((double)scheme.Players.SelectMany(p => p.Player.Stats).Sum(m => m.Value)
                / (scheme.Players.SelectMany(p => p.Player.Stats).Count() * PlayerConstants.StatMaxValue)
                * ValidationConstants.PercentageMaxValue)) >= from;
        }

        if (to.HasValue)
        {
            return scheme => ((int)Math.Ceiling((double)scheme.Players.SelectMany(p => p.Player.Stats).Sum(m => m.Value)
                / (scheme.Players.SelectMany(p => p.Player.Stats).Count() * PlayerConstants.StatMaxValue)
                * ValidationConstants.PercentageMaxValue)) <= to;
        }

        return player => true;
    }
}