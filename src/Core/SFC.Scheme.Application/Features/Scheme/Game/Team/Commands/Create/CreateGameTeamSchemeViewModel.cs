using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Game.Team;

namespace SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Create;
public class CreateGameTeamSchemeViewModel : IMapFrom<GameTeamScheme>
{
    public required GameTeamSchemeDto Scheme { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<GameTeamScheme, CreateGameTeamSchemeViewModel>()
                                                   .ForMember(p => p.Scheme, d => d.MapFrom(z => z));
}