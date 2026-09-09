using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Create;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Create;

/// <summary>
/// **Create** team scheme response model.
/// </summary>
public class CreateGameTeamSchemeResponse :
    BaseErrorResponse, IMapFrom<CreateGameTeamSchemeViewModel>
{
    /// <summary>
    /// Team scheme model.
    /// </summary>
    public GameTeamSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGameTeamSchemeViewModel, CreateGameTeamSchemeResponse>()
                                                   .IgnoreAllNonExisting();
}