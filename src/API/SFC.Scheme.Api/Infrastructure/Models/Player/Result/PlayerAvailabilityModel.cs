using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Player.Result;

/// <summary>
/// Player's **availability** model (when player is available to play).
/// </summary>
public class PlayerAvailabilityModel :
    RangeLimitModel<TimeSpan?>,
    IMapFromReverse<PlayerAvailabilityDto>
{
    /// <summary>
    /// Days of week.
    /// </summary>
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}