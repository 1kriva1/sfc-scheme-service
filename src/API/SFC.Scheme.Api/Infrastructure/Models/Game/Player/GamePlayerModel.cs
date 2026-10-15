using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Game.Team.Player;
using SFC.Scheme.Api.Infrastructure.Models.Player;
using SFC.Scheme.Application.Common.Dto.Game.Player;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Game.Player;

/// <summary>
/// Game Player model.
/// </summary>
public class GamePlayerModel : IMapFrom<GamePlayerDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game Player status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Game Player related to this player.
    /// </summary>
    public PlayerModel? Player { get; set; }

    /// <summary>
    /// Game Team Player related to this game player.
    /// </summary>
    public GameTeamPlayerModel? GameTeamPlayer { get; set; }


    public void Mapping(Profile profile) => profile.CreateMap<GamePlayerDto, GamePlayerModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}