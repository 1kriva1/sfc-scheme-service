using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Dto.Team.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Team.General;

/// <summary>
/// Team's **availability** model (when team is available to play).
/// </summary>
public class TeamAvailabilityModel :
    RangeLimitModel<TimeSpan?>,
    IMapFromReverse<TeamAvailabilityDto>
{
    /// <summary>
    /// Day of week.
    /// </summary>
    public DayOfWeek Day { get; set; }
}