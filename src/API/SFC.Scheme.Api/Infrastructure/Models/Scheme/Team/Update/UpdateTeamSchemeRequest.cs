using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Update;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Update;

/// <summary>
/// **Update** team scheme request.
/// </summary>
public class UpdateTeamSchemeRequest : IMapTo<UpdateTeamSchemeCommand>
{
    /// <summary>
    /// Team scheme model.
    /// </summary>
    public UpdateTeamSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateTeamSchemeRequest, UpdateTeamSchemeCommand>()
                                                   .IgnoreAllNonExisting();
}