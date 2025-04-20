using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Application.Features.Common.Dto.Pagination;

namespace SFC.Scheme.Api.Infrastructure.Models.Pagination;

/// <summary>
/// **Pagination** metadata model.
/// </summary>
public class PageMetadataModel : IMapFrom<PageMetadataDto>
{
    /// <summary>
    /// **Current** page.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Total **pages** count.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// Page **size**.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Total **items** count.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Describe if **previous** page **exist** for defined filters and page size.
    /// </summary>
    public bool HasPreviousPage { get; set; }

    /// <summary>
    /// Describe if **next** page **exist** for defined filters and page size.
    /// </summary>
    public bool HasNextPage { get; set; }

    /// <summary>
    /// Links model.
    /// </summary>
    public PageLinksModel Links { get; set; } = default!;
}