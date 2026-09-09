using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find;

/// <summary>
/// **Get** team schemes response.
/// </summary>
public class GetGameTeamSchemesResponse : BaseListResponse<GameTeamSchemeModel>, IMapFrom<GetGameTeamSchemesViewModel>
{
    public void Mapping(Profile profile) => profile.CreateMap<GetGameTeamSchemesViewModel, GetGameTeamSchemesResponse>()
                                                   .IgnoreAllNonExisting();
}