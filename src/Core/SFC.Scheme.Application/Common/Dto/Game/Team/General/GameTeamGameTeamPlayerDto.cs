using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Application.Common.Dto.Game.Team.General;
public class GameTeamGameTeamPlayerDto : IMapFromReverse<GameTeamPlayer>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameTeamId { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public int StatusId { get; set; }

    public PlayerDto? Player { get; set; }

    //public void Mapping(Profile profile) => profile.CreateMap<GameTeamPlayer, GameTeamGameTeamPlayerDto>()
    //                                               .ForMember(p => p.GameId, d => d.MapFrom(z => z.GameTeam.GameId))
    //                                               .ForMember(p => p.TeamId, d => d.MapFrom(z => z.GameTeam.TeamId))
    //                                               .ReverseMap();
}