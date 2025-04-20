using AutoMapper;

using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Commands.Update;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Update;

/// <summary>
/// **Update** scheme request.
/// </summary>
public class UpdateSchemeRequest : IMapTo<UpdateSchemeCommand>
{
    /// <summary>
    /// Scheme model.
    /// </summary>
    public UpdateSchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<UpdateSchemeRequest, UpdateSchemeCommand>()
                                                   .IgnoreAllNonExisting();
}