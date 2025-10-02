using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
public class TeamSchemeGeneralProfileDto : IMapFrom<TeamScheme>, IMapTo<TeamSchemeGeneralProfile>
{
    public required string Name { get; set; }

    public string? Comment { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamScheme, TeamSchemeGeneralProfileDto>()
               .ForMember(p => p.Name, d => d.MapFrom(z => z.GeneralProfile.Name))
               .ForMember(p => p.Comment, d => d.MapFrom(z => z.GeneralProfile.Comment))
               .ReverseMap();

        profile.CreateMap<TeamSchemeGeneralProfileDto, TeamSchemeGeneralProfile>()
               .IgnoreAllNonExisting();
    }
}