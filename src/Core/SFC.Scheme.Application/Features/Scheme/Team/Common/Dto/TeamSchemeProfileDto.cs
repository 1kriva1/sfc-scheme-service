using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
public class TeamSchemeProfileDto : IMapFrom<TeamScheme>
{
    public required TeamSchemeGeneralProfileDto General { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamScheme, TeamSchemeProfileDto>()
               .ForMember(p => p.General, d => d.MapFrom(z => z));
    }
}