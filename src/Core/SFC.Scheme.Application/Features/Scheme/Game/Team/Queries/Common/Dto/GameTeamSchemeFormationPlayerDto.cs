using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Common.Dto;
public class GameTeamSchemeFormationPlayerDto : IMapToReverse<GameTeamSchemeFormationPlayer>
{
    public required PlayerDto Player { get; set; }

    public required GameTeamSchemeFormationPlayerPositionDto Position { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GameTeamSchemeFormationPlayerDto, GameTeamSchemeFormationPlayer>()
            .ForMember(p => p.DomainEvents, d => d.Ignore())
            .ForMember(p => p.Id, d => d.Ignore())
            .ForMember(p => p.Player, d => d.Ignore())
            .ReverseMap();
    }
}