using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;

namespace SFC.Scheme.Application.Features.Scheme.Commands.Update;
public class UpdateSchemeDto : IMapTo<SchemeEntity>
{
    public long Id { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<UpdateSchemeDto, SchemeEntity>();
}