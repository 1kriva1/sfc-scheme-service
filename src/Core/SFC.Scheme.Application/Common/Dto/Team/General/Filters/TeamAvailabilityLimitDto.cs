using SFC.Scheme.Application.Features.Common.Dto.Common;

namespace SFC.Scheme.Application.Common.Dto.Team.General.Filters;
public class TeamAvailabilityLimitDto : RangeLimitDto<TimeSpan?>
{
    public IEnumerable<DayOfWeek> Days { get; set; } = [];
}