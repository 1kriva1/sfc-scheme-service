using AutoMapper;

using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Data.Common;

/// <summary>
/// **Formation** data value.
/// </summary>
public class FormationDataValueModel : DataValueModel, IMapFrom<FormationDataValueDto>
{
    /// <summary>
    /// Schema  as array of arrays, which represent formation.
    /// First array - lines
    /// Second array - formation positions
    /// </summary>
    public IEnumerable<IEnumerable<int>> Values { get; set; } = [];

    public void Mapping(Profile profile) => profile.CreateMap<FormationDataValueDto, FormationDataValueModel>()
                                                   .IncludeBase<DataValueDto, DataValueModel>();
}