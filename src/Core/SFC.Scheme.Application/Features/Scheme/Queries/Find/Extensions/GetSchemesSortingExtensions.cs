using System.Linq.Expressions;

using SFC.Scheme.Application.Features.Common.Dto.Common;
using SFC.Scheme.Application.Features.Common.Extensions;
using SFC.Scheme.Application.Features.Common.Models.Find.Sorting;

namespace SFC.Scheme.Application.Features.Scheme.Queries.Find.Extensions;
public static class GetSchemesSortingExtensions
{
    public static IEnumerable<Sorting<SchemeEntity, dynamic>> BuildSchemeSearchSorting(this IEnumerable<SortingDto> sorting)
        => sorting.BuildSearchSorting<SchemeEntity>(BuildExpression);

    private static Expression<Func<SchemeEntity, dynamic>>? BuildExpression(string name)
    {
        return name switch
        {
            _ => null
        };
    }
}