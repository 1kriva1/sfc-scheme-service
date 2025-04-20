using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Player;
public abstract class BasePlayerEntity : BaseEntity<long>
{
    public Player Player { get; set; } = null!;
}