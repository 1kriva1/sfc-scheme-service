using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find;

/// <summary>
/// **Get** team schemes response.
/// </summary>
public class GetTeamSchemesResponse : BaseListResponse<TeamSchemeModel>, IMapFrom<GetTeamSchemesViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetTeamSchemesViewModel, GetTeamSchemesResponse>()
                                                   .IgnoreAllNonExisting();
}