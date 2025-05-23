using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Scheme.Data.Queries.Common.Dto;

namespace SFC.Scheme.Api.Infrastructure.Models.Scheme.Data.Common;

/// <summary>
/// Data value.
/// </summary>
public class DataValueModel : IMapFrom<DataValueDto>
{
    /// <summary>
    /// Unique identificator of data type.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Describe data type.
    /// </summary>
    public required string Title { get; set; }
}