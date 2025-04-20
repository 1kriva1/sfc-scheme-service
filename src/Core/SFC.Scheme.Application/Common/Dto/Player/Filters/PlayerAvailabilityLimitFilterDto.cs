using SFC.Scheme.Application.Features.Common.Dto.Common;

namespace SFC.Scheme.Application.Common.Dto.Player.Filters;
public class PlayerAvailabilityLimitFilterDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}