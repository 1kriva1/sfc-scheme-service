using SFC.Scheme.Application.Features.Common.Models.Find.Filters;
using SFC.Scheme.Application.Features.Scheme.Queries.Find.Dto.Filters;

namespace SFC.Scheme.Application.Features.Scheme.Queries.Find.Extensions;
public static class GetSchemesFiltersExtensions
{
    public static IEnumerable<Filter<SchemeEntity>> BuildSearchFilters(this GetSchemesFilterDto filter)
    {
        return [];
    }
}