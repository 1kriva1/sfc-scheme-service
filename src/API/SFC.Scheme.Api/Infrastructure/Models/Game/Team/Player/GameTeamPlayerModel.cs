using SFC.Scheme.Api.Infrastructure.Models.Game.Team.General;
using SFC.Scheme.Api.Infrastructure.Models.Player;
using SFC.Scheme.Application.Common.Dto.Game.Team.Player;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Game.Team.Player;

/// <summary>
/// Game Team Player model.
/// </summary>
public class GameTeamPlayerModel : IMapFrom<GameTeamPlayerDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game Team Player related to this player.
    /// </summary>
    public PlayerModel? Player { get; set; }

    /// <summary>
    /// Game Team related to this game team player.
    /// </summary>
    public GameTeamModel? GameTeam { get; set; }
}