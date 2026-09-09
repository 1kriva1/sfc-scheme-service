using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Get;
public class GetGameTeamSchemeViewModel : IMapFrom<GameTeamScheme>
{
    public required GameTeamSchemeDto Scheme { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamScheme, GetGameTeamSchemeViewModel>()
                                                   .ForMember(p => p.Scheme, d => d.MapFrom(z => z));
}