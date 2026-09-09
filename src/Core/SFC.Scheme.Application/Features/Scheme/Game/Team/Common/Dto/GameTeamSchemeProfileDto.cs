using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Common.Dto;
public class GameTeamSchemeProfileDto : IMapFrom<GameTeamScheme>
{
    public required GameTeamSchemeGeneralProfileDto General { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<GameTeamScheme, GameTeamSchemeProfileDto>()
               .ForMember(p => p.General, d => d.MapFrom(z => z));
    }
}