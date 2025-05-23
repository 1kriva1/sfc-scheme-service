using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Common.Dto;
public class TeamSchemeGeneralProfileDto : IMapFrom<TeamScheme>, IMapTo<TeamSchemeGeneralProfile>
{
    public required string Name { get; set; }

    public string? Comment { get; set; }

    public int TypeId { get; set; }

    public int FormationId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TeamScheme, TeamSchemeGeneralProfileDto>()
               .ForMember(p => p.Name, d => d.MapFrom(z => z.GeneralProfile.Name))
               .ForMember(p => p.Comment, d => d.MapFrom(z => z.GeneralProfile.Comment))
               .ForMember(p => p.FormationId, d => d.MapFrom(z => z.GeneralProfile.FormationId))
               .ForMember(p => p.TypeId, d => d.MapFrom(z => z.GeneralProfile.TypeId))
               .ReverseMap();

        profile.CreateMap<TeamSchemeGeneralProfileDto, TeamSchemeGeneralProfile>()
               .IgnoreAllNonExisting();
    }
}