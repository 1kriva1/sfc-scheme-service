using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Commands.Create;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Create;

/// <summary>
/// **Create** Scheme request.
/// </summary>
public class CreateSchemeRequest : IMapTo<CreateSchemeCommand>
{
    /// <summary>
    /// Scheme model.
    /// </summary>
    public CreateSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateSchemeRequest, CreateSchemeCommand>()
                                                   .IgnoreAllNonExisting();
}