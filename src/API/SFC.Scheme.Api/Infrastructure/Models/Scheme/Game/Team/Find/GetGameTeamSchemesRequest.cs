using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find.Filters;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find;

/// <summary>
/// **Get** team schemes request.
/// </summary>
public class GetGameTeamSchemesRequest : BasePaginationRequest<GetGameTeamSchemesFilterModel>, IMapTo<GetGameTeamSchemesQuery>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGameTeamSchemesRequest, GetGameTeamSchemesQuery>()
                                                   .IgnoreAllNonExisting();
}