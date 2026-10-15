using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Common;
using SFC.Scheme.Application.Common.Dto.Game.Team.General;
using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Game.Team.Player;

namespace SFC.Scheme.Application.Common.Dto.Game.Team.Player;

public class GameTeamPlayerDto : AuditableDto, IMapFromReverse<GameTeamPlayer>
{
    public long Id { get; set; }

    public Guid UserId { get; set; }

    public long GameId { get; set; }

    public long TeamId { get; set; }

    public long PlayerId { get; set; }

    public PlayerDto? Player { get; set; }

    public GameTeamDto? GameTeam { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamPlayer, GameTeamPlayerDto>()
                                                   .ForMember(p => p.GameId, d => d.MapFrom(z => z.GameTeam.GameId))
                                                   .ForMember(p => p.TeamId, d => d.MapFrom(z => z.GameTeam.TeamId))
                                                   .ForMember(p => p.PlayerId, d => d.MapFrom(z => z.GamePlayer != null ? z.GamePlayer!.PlayerId : z.TeamPlayer!.PlayerId))
                                                   .ForMember(p => p.Player, d => d.MapFrom(z => z.GamePlayer != null ? z.GamePlayer!.Player : z.TeamPlayer!.Player));
}