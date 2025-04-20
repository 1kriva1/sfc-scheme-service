using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Dto.Player.Filters;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Player.Find.Filters;

/// <summary>
/// Get players **availability filter** model.
/// </summary>
public class PlayerAvailabilityLimitFilterModel :
    RangeLimitModel<TimeSpan?>,
    IMapTo<PlayerAvailabilityLimitFilterDto>
{
    /// <summary>
    /// Day of week.
    /// </summary>
    public IEnumerable<int> Days { get; set; } = default!;
}