using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Common.Dto;

namespace SFC.Scheme.Application.Features.Scheme.Queries.Get;
public class GetSchemeViewModel : IMapFrom<SchemeEntity>
{
    public required SchemeDto Scheme { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<SchemeEntity, GetSchemeViewModel>()
                                                   .ForMember(p => p.Scheme, d => d.MapFrom(z => z));
}