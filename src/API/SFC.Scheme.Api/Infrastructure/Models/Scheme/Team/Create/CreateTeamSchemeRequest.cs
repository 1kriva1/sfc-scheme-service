using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Create;

/// <summary>
/// **Create** Team scheme request.
/// </summary>
public class CreateTeamSchemeRequest : IMapTo<CreateTeamSchemeCommand>
{
    /// <summary>
    /// Team scheme model.
    /// </summary>
    public CreateTeamSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateTeamSchemeRequest, CreateTeamSchemeCommand>()
                                                   .IgnoreAllNonExisting();
}