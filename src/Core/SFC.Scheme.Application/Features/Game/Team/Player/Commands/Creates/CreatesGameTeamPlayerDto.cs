using SFC.Scheme.Application.Common.Dto.Common;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Application.Features.Game.Team.Player.Commands.Creates;

public class CreatesGameTeamPlayerDto : AuditableDto, IMapTo<GameTeamPlayer>
{
    public long Id { get; set; }

    public long GameTeamId { get; set; }

    public long? GamePlayerId { get; set; }

    public long? TeamPlayerId { get; set; }

    public Guid UserId { get; set; }
}