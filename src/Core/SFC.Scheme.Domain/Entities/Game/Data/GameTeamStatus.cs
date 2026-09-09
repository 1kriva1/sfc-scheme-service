using SFC.Scheme.Domain.Common;

namespace SFC.Scheme.Domain.Entities.Game.Data;
public class GameTeamStatus : EnumDataEntity<GameTeamStatusEnum>
{
    public GameTeamStatus() : base() { }

    public GameTeamStatus(GameTeamStatusEnum enumType) : base(enumType) { }
}