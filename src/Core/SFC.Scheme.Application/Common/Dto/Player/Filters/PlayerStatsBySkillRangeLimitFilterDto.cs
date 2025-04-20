using SFC.Scheme.Application.Features.Common.Dto.Common;

namespace SFC.Scheme.Application.Common.Dto.Player.Filters;
public class PlayerStatsBySkillRangeLimitFilterDto : RangeLimitDto<short?>
{
    public int Skill { get; set; }
}