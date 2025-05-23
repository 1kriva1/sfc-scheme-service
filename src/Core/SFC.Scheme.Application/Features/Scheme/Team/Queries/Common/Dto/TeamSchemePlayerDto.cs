using AutoMapper;

using SFC.Scheme.Application.Common.Dto.Player.General;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
using SFC.Scheme.Domain.Entities.Player;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;
public class TeamSchemePlayerDto : IMapToReverse<TeamSchemePlayer>
{
    public required PlayerDto Player { get; set; }

    public required TeamSchemePlayerPositionDto Position { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamSchemePlayerDto, TeamSchemePlayer>()
            .ForMember(p => p.DomainEvents, d => d.Ignore())
            .ForMember(p => p.Id, d => d.Ignore())
            .ForMember(p => p.Player, d => d.Ignore())
            .ReverseMap();
    }
}