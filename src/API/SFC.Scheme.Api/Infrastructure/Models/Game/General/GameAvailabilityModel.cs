using SFC.Scheme.Api.Infrastructure.Models.Common;
using SFC.Scheme.Application.Common.Dto.Game.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Game.General;

/// <summary>
/// Game's **availability** model (when game is available to play).
/// </summary>
public class GameAvailabilityModel :
    RangeLimitModel<TimeSpan?>,
    IMapFromReverse<GameAvailabilityDto>
{
    /// <summary>
    /// Date.
    /// </summary>
    public DateOnly Date { get; set; }
}