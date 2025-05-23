using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Common.Dto;
using SFC.Scheme.Domain.Entities.Scheme.Team;

namespace SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;
public class CreateTeamSchemeViewModel : IMapFrom<TeamScheme>
{
    public required TeamSchemeDto Scheme { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<TeamScheme, CreateTeamSchemeViewModel>()
                                                   .ForMember(p => p.Scheme, d => d.MapFrom(z => z));
}