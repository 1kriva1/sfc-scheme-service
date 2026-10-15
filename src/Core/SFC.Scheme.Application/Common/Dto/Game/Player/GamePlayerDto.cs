using SFC.Scheme.Application.Common.Dto.Common;
using SFC.Scheme.Application.Common.Dto.Game.Team.Player;
using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Game.Player;

namespace SFC.Scheme.Application.Common.Dto.Game.Player;
public class GamePlayerDto : AuditableDto, IMapFromReverse<GamePlayer>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public PlayerDto? Player { get; set; }

    public GameTeamPlayerDto? GameTeamPlayer { get; set; }
}