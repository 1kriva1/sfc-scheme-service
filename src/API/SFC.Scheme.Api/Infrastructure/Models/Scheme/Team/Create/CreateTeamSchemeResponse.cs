using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Create;

/// <summary>
/// **Create** team scheme response model.
/// </summary>
public class CreateTeamSchemeResponse :
    BaseErrorResponse, IMapFrom<CreateTeamSchemeViewModel>
{
    /// <summary>
    /// Team scheme model.
    /// </summary>
    public TeamSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamSchemeViewModel, CreateTeamSchemeResponse>()
                                                   .IgnoreAllNonExisting();
}