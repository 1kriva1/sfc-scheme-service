using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Game.General;
public abstract class BaseGameEntity : BaseEntity<long>
{
    public GameEntity Game { get; set; } = null!;
}