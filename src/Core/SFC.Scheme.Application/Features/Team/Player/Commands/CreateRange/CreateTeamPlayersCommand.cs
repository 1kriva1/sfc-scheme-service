using SFC.Scheme.Application.Common.Dto.Team.Player;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Team.Player.Commands.CreateRange;
public class CreateTeamPlayersCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateTeamPlayers; }

    public IEnumerable<TeamPlayerDto> TeamPlayers { get; set; } = null!;
}