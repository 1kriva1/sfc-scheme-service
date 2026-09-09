using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Create;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Create;

/// <summary>
/// **Create** Team scheme request.
/// </summary>
public class CreateGameTeamSchemeRequest : IMapTo<CreateGameTeamSchemeCommand>
{
    /// <summary>
    /// Team scheme model.
    /// </summary>
    public CreateGameTeamSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateGameTeamSchemeRequest, CreateGameTeamSchemeCommand>()
                                                   .IgnoreAllNonExisting();
}