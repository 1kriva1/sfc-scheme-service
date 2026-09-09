using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;
public class GameTeamSchemeGeneralProfileDto : IMapFrom<GameTeamScheme>, IMapTo<GameTeamSchemeGeneralProfile>
{
    public required string Name { get; set; }

    public string? Comment { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GameTeamScheme, GameTeamSchemeGeneralProfileDto>()
               .ForMember(p => p.Name, d => d.MapFrom(z => z.GeneralProfile.Name))
               .ForMember(p => p.Comment, d => d.MapFrom(z => z.GeneralProfile.Comment))
               .ReverseMap();

        profile.CreateMap<GameTeamSchemeGeneralProfileDto, GameTeamSchemeGeneralProfile>()
               .ReverseMap()
               .IgnoreAllNonExisting();
    }
}