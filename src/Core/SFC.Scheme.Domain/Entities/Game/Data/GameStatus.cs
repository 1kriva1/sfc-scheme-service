using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Game.Data;
public class GameStatus : EnumDataEntity<GameStatusEnum>
{
    public GameStatus() : base() { }

    public GameStatus(GameStatusEnum enumType) : base(enumType) { }
}