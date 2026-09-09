using SFC.Scheme.Application.Common.Dto.Game.Team;
using SFC.Scheme.Application.Common.Enums;
using SFC.Scheme.Application.Features.Common.Base;

namespace SFC.Scheme.Application.Features.Game.Team.Commands.Creates;
public class CreatesGameTeamCommand : Request
{
    public override RequestId RequestId { get => RequestId.CreateGameTeams; }

    public IEnumerable<GameTeamDto> GameTeams { get; set; } = null!;
}