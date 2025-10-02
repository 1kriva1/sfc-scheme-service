using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Team.General;

namespace SFC.Scheme.Application.Common.Dto.Team.General;
public class TeamInventaryProfileDto : IMapToReverse<TeamInventaryProfile>
{
    public IEnumerable<int> Shirts { get; set; } = [];

    public bool HasManiches { get; set; }
}