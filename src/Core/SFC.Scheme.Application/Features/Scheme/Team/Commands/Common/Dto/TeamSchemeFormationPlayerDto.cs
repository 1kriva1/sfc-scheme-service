using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Common.Dto;
public class TeamSchemeFormationPlayerDto : IMapToReverse<TeamSchemeFormationPlayer>
{
    public long PlayerId { get; set; }

    public required TeamSchemeFormationPlayerPositionDto Position { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamSchemeFormationPlayerDto, TeamSchemeFormationPlayer>()
               .ForMember(p => p.DomainEvents, d => d.Ignore())
               .ForMember(p => p.Id, d => d.Ignore())
               .ForMember(p => p.Player, d => d.Ignore())
               .ReverseMap();
    }
}