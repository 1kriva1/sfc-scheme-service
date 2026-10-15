using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Game.Data;
public class GamePlayerStatus : EnumDataEntity<GamePlayerStatusEnum>
{
    public GamePlayerStatus() : base() { }

    public GamePlayerStatus(GamePlayerStatusEnum enumType) : base(enumType) { }
}