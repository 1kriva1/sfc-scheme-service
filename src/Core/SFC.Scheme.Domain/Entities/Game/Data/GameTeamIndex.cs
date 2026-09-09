using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Game.Data;
public class GameTeamIndex : EnumDataEntity<GameTeamIndexEnum>
{
    public GameTeamIndex() : base() { }

    public GameTeamIndex(GameTeamIndexEnum enumType) : base(enumType) { }
}