using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Commands.Create;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Create;

/// <summary>
/// **Create** scheme response model.
/// </summary>
public class CreateSchemeResponse :
    BaseErrorResponse, IMapFrom<CreateSchemeViewModel>
{
    /// <summary>
    /// Scheme model.
    /// </summary>
    public SchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<CreateSchemeViewModel, CreateSchemeResponse>()
                                                   .IgnoreAllNonExisting();
}