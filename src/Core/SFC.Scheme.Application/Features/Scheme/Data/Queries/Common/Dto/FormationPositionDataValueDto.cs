using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Scheme.Data;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;
public class FormationPositionDataValueDto : DataValueDto, IMapFrom<FormationPosition>
{
    public int FootballPositionId { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<FormationPosition, FormationPositionDataValueDto>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));
}