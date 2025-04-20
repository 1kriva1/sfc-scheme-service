using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Find.Filters;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Queries.Find;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Find;

/// <summary>
/// **Get** schemes request.
/// </summary>
public class GetSchemesRequest : BasePaginationRequest<GetSchemesFilterModel>, IMapTo<GetSchemesQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetSchemesRequest, GetSchemesQuery>()
                                                   .IgnoreAllNonExisting();
}