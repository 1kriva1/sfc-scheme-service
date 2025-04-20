using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Team.General;

namespace SFC.Scheme.Application.Common.Dto.Team.General;
public class TeamFinancialProfileDto : IMapFromReverse<TeamFinancialProfile>
{
    public bool FreePlay { get; set; }
}