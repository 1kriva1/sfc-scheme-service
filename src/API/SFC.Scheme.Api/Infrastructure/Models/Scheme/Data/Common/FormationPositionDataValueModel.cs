using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Data.Common;

/// <summary>
/// **Formation position** data value.
/// </summary>
public class FormationPositionDataValueModel : DataValueModel, IMapFrom<FormationPositionDataValueDto>
{
    /// <summary>
    /// Football position of **formation position**.
    /// </summary>
    public int FootballPosition { get; set; }

    public void Mapping(Profile profile) => profile.CreateMap<FormationPositionDataValueDto, FormationPositionDataValueModel>()
                                                   .ForMember(p => p.FootballPosition, d => d.MapFrom(z => z.FootballPositionId))
                                                   .IncludeBase<DataValueDto, DataValueModel>();
}