using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Player;
using SFC.Scheme.Application.Common.Dto.Game.Team.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Api.Infrastructure.Models.Game.Team.General;

/// <summary>
/// Game Team Player model.
/// </summary>
public class GameTeamGameTeamPlayerModel : IMapFrom<GameTeamGameTeamPlayerDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Game Team Player status.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Game Team Player related to this player.
    /// </summary>
    public PlayerModel? Player { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamGameTeamPlayerDto, GameTeamGameTeamPlayerModel>()
                                                   .ForMember(p => p.Status, d => d.MapFrom(z => z.StatusId));
}