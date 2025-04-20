using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Team.General;
public abstract class BaseTeamEntity : BaseEntity<long>
{
    public TeamEntity Team { get; set; } = null!;
}