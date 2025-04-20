using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Queries.Find;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Find;

/// <summary>
/// **Get** schemes response.
/// </summary>
public class GetSchemesResponse : BaseListResponse<SchemeModel>, IMapFrom<GetSchemesViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetSchemesViewModel, GetSchemesResponse>()
                                                   .IgnoreAllNonExisting();
}