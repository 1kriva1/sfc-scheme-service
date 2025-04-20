using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Scheme.Api.Infrastructure.Extensions;
using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Pagination;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Create;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Find;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Get;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Update;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Scheme.Commands.Create;
using SFC.Scheme.Application.Features.Scheme.Commands.Update;
using SFC.Scheme.Application.Features.Scheme.Queries.Find;
using SFC.Scheme.Application.Features.Scheme.Queries.Find.Dto.Filters;
using SFC.Scheme.Application.Features.Scheme.Queries.Get;
using SFC.Scheme.Infrastructure.Constants;

namespace SFC.Scheme.Api.Controllers;

[Tags("Schemes")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class SchemesController : ApiControllerBase
{
    /// <summary>
    /// Create new scheme.
    /// </summary>
    /// <param name="request">Create scheme request.</param>
    /// <returns>An ActionResult of type CreateSchemeResponse</returns>
    /// <response code="201">Returns **new** created scheme.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpPost]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CreateSchemeResponse>> CreateSchemeAsync([FromBody] CreateSchemeRequest request)
    {
        CreateSchemeCommand command = Mapper.Map<CreateSchemeCommand>(request);

        CreateSchemeViewModel model = await Mediator.Send(command).ConfigureAwait(false);

        return CreatedAtRoute("GetScheme", new { id = model.Scheme.Id }, Mapper.Map<CreateSchemeResponse>(model));
    }

    /// <summary>
    /// Update existing scheme.
    /// </summary>
    /// <param name="id">Scheme unique identifier.</param>
    /// <param name="request">Update scheme request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if scheme updated **successfully**.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpPut("{id}")]
    [Authorize(Policy.OwnScheme)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> UpdateSchemeAsync([FromRoute] long id, [FromBody] UpdateSchemeRequest request)
    {
        UpdateSchemeCommand command = Mapper.Map<UpdateSchemeCommand>(request)
                                                     .SetSchemeId(id);

        await Mediator.Send(command).ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return scheme model by unique identifier.
    /// </summary>
    /// <param name="id">Scheme unique identifier.</param>
    /// <returns>An ActionResult of type GetSchemeResponse</returns>
    /// <response code="200">Returns scheme model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when scheme **not found** by unique identifier.</response>
    [HttpGet("{id}", Name = "GetScheme")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetSchemeResponse>> GetSchemeAsync([FromRoute] long id)
    {
        GetSchemeQuery query = new() { Id = id };

        GetSchemeViewModel scheme = await Mediator.Send(query).ConfigureAwait(false);

        return Ok(Mapper.Map<GetSchemeResponse>(scheme));
    }

    /// <summary>
    /// Return list of schemes
    /// </summary>
    /// <param name="request">Get schemes request.</param>
    /// <returns>An ActionResult of type GetSchemesResponse</returns>
    /// <response code="200">Returns list of schemes with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetSchemesResponse>> GetSchemesAsync([FromQuery] GetSchemesRequest request)
    {
        BasePaginationRequest<GetSchemesViewModel, GetSchemesFilterDto> query = Mapper.Map<GetSchemesQuery>(request);

        GetSchemesViewModel result = await Mediator.Send(query).ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetSchemesResponse>(result));
    }
}