using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Get;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Get;

/// <summary>
/// **Get** team scheme response.
/// </summary>
public class GetTeamSchemeResponse :
    BaseErrorResponse, IMapFrom<GetTeamSchemeViewModel>
{
    /// <summary>
    /// Team scheme model.
    /// </summary>
    public TeamSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetTeamSchemeViewModel, GetTeamSchemeResponse>()
                                                   .IgnoreAllNonExisting();
}