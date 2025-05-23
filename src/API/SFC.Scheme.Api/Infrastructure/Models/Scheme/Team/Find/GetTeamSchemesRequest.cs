using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find.Filters;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find;

/// <summary>
/// **Get** team schemes request.
/// </summary>
public class GetTeamSchemesRequest : BasePaginationRequest<GetTeamSchemesFilterModel>, IMapTo<GetTeamSchemesQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamSchemesRequest, GetTeamSchemesQuery>()
                                                   .IgnoreAllNonExisting();
}