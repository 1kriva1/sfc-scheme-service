using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Data.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Data.Queries.GetAll;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Data.GetAll;

/// <summary>
/// Contain all available scheme **data types**.
/// </summary>
public class GetAllSchemeDataResponse : BaseErrorResponse, IMapFrom<GetAllSchemeDataViewModel>
{
    /// <summary>
    /// Formations.
    /// </summary>
    public IEnumerable<FormationDataValueModel> Formations { get; init; } = [];

    /// <summary>
    /// Formation positions.
    /// </summary>
    public IEnumerable<FormationPositionDataValueModel> FormationPositions { get; init; } = [];

    /// <summary>
    /// Formation positions.
    /// </summary>
    public IEnumerable<DataValueModel> SchemeTypes { get; init; } = [];

    public void Mapping(Profile profile) => profile.CreateMap<GetAllSchemeDataViewModel, GetAllSchemeDataResponse>()
                                                   .IgnoreAllNonExisting();
}