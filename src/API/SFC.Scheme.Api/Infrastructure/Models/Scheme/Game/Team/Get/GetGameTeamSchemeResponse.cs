using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Get;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Get;

/// <summary>
/// **Get** team scheme response.
/// </summary>
public class GetGameTeamSchemeResponse :
    BaseErrorResponse, IMapFrom<GetGameTeamSchemeViewModel>
{
    /// <summary>
    /// Team scheme model.
    /// </summary>
    public GameTeamSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetGameTeamSchemeViewModel, GetGameTeamSchemeResponse>()
                                                   .IgnoreAllNonExisting();
}