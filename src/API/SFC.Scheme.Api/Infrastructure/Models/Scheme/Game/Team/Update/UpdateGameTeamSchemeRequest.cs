using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Update;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Update;

/// <summary>
/// **Update** team scheme request.
/// </summary>
public class UpdateGameTeamSchemeRequest : IMapTo<UpdateGameTeamSchemeCommand>
{
    /// <summary>
    /// Team scheme model.
    /// </summary>
    public UpdateGameTeamSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateGameTeamSchemeRequest, UpdateGameTeamSchemeCommand>()
                                                   .IgnoreAllNonExisting();
}