using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Common;

/// <summary>
/// Scheme model.
/// </summary>
public class SchemeModel : IMapFrom<SchemeDto>
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public long Id { get; set; }
}