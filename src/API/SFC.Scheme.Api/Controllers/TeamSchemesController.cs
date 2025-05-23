using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Scheme.Api.Infrastructure.Extensions;
using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Pagination;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Create;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Find;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Get;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Team.Update;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Create;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Delete;
using SFC.Scheme.Application.Features.Scheme.Team.Commands.Update;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Find.Dto.Filters;
using SFC.Scheme.Application.Features.Scheme.Team.Queries.Get;
using SFC.Scheme.Infrastructure.Constants;

namespace SFC.Scheme.Api.Controllers;

[Tags("Team Schemes")]
[Route("api/Schemes")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class TeamSchemesController : ApiControllerBase
{
    /// <summary>
    /// Create new team scheme.
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="request">Create team scheme request.</param>
    /// <returns>An ActionResult of type CreateTeamSchemeResponse</returns>
    /// <response code="201">Returns **new** created team scheme.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpPost("Teams/{teamId}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CreateTeamSchemeResponse>> CreateTeamSchemeAsync([FromRoute] long teamId, [FromBody] CreateTeamSchemeRequest request)
    {
        CreateTeamSchemeCommand command = Mapper.Map<CreateTeamSchemeCommand>(request)
                                                .SetTeamId(teamId);

        CreateTeamSchemeViewModel model = await Mediator.Send(command).ConfigureAwait(false);

        return CreatedAtRoute("GetTeamScheme", new { id = model.Scheme.Id }, Mapper.Map<CreateTeamSchemeResponse>(model));
    }

    /// <summary>
    /// Update existing team scheme.
    /// </summary>
    /// <param name="id">Team scheme unique identifier.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="request">Update team scheme request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if team scheme updated **successfully**.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when scheme **not found** by unique identifier.</response>
    [HttpPut("{id}/Teams/{teamId}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateTeamSchemeAsync([FromRoute] long id, [FromRoute] long teamId, [FromBody] UpdateTeamSchemeRequest request)
    {
        UpdateTeamSchemeCommand command = Mapper.Map<UpdateTeamSchemeCommand>(request)
                                                .SetSchemeId(id)
                                                .SetTeamId(teamId);

        await Mediator.Send(command).ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Delete existing team scheme.
    /// </summary>
    /// <param name="id">Team scheme unique identifier.</param>
    /// <param name="teamId">Team Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if team scheme deleted **successfully**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when scheme **not found** by unique identifier.</response>
    [HttpDelete("{id}/Teams/{teamId}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DeleteTeamSchemeAsync([FromRoute] long id, [FromRoute] long teamId)
    {
        DeleteTeamSchemeCommand command = new() { Scheme = new() { Id = id, TeamId = teamId } };

        await Mediator.Send(command).ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return team scheme model by unique identifier.
    /// </summary>
    /// <param name="id">Team scheme unique identifier.</param>
    /// <returns>An ActionResult of type GetTeamSchemeResponse</returns>
    /// <response code="200">Returns scheme model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when scheme **not found** by unique identifier.</response>
    [HttpGet("{id}/Teams", Name = "GetTeamScheme")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetTeamSchemeResponse>> GetTeamSchemeAsync([FromRoute] long id)
    {
        GetTeamSchemeQuery query = new() { Id = id };

        GetTeamSchemeViewModel scheme = await Mediator.Send(query).ConfigureAwait(false);

        return Ok(Mapper.Map<GetTeamSchemeResponse>(scheme));
    }

    /// <summary>
    /// Return list of team schemes
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="request">Get team schemes request.</param>
    /// <returns>An ActionResult of type GetTeamSchemesResponse</returns>
    /// <response code="200">Returns list of team schemes with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Teams/{teamId}/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetTeamSchemesResponse>> GetTeamSchemesAsync([FromRoute] long teamId, [FromQuery] GetTeamSchemesRequest request)
    {
        BasePaginationRequest<GetTeamSchemesViewModel, GetTeamSchemesFilterDto> query = Mapper.Map<GetTeamSchemesQuery>(request)
                                                                                              .SetTeamId(teamId);

        GetTeamSchemesViewModel result = await Mediator.Send(query).ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetTeamSchemesResponse>(result));
    }
}