using AutoMapper;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Common;
using SFC.Scheme.Application.Common.Extensions;
using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Queries.Get;

#pragma warning disable CA1716
namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Get;
#pragma warning restore CA1716

/// <summary>
/// **Get** scheme response.
/// </summary>
public class GetSchemeResponse :
    BaseErrorResponse, IMapFrom<GetSchemeViewModel>
{
    /// <summary>
    /// Scheme model.
    /// </summary>
    public SchemeModel Scheme { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<GetSchemeViewModel, GetSchemeResponse>()
                                                   .IgnoreAllNonExisting();
}