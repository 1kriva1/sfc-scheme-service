using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Scheme.Api.Infrastructure.Extensions;
using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Pagination;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Create;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Find;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Get;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Game.Team.Update;
using SFC.Scheme.Application.Features.Common.Base;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Create;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Delete;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Commands.Update;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Find.Dto.Filters;
using SFC.Scheme.Application.Features.Scheme.Game.Team.Queries.Get;
using SFC.Scheme.Infrastructure.Constants;

namespace SFC.Scheme.Api.Controllers;

[Tags("game team schemes")]
[Route("api/Schemes")]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
public class GameTeamSchemesController : ApiControllerBase
{
    /// <summary>
    /// Create new game team scheme.
    /// </summary>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="request">Create game team scheme request.</param>
    /// <returns>An ActionResult of type CreateTeamSchemeResponse</returns>
    /// <response code="201">Returns **new** created game team scheme.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpPost("Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CreateGameTeamSchemeResponse>> CreateGameTeamSchemeAsync([FromRoute] long gameId, [FromRoute] long teamId, [FromBody] CreateGameTeamSchemeRequest request)
    {
        CreateGameTeamSchemeCommand command = Mapper.Map<CreateGameTeamSchemeCommand>(request)
                                                .SetGameId(gameId)
                                                .SetTeamId(teamId);

        CreateGameTeamSchemeViewModel model = await Mediator.Send(command).ConfigureAwait(false);

        return CreatedAtRoute("GetGameTeamScheme", new { id = model.Scheme.Id, gameId = model.Scheme.Game.Id, teamId = model.Scheme.Team.Id }, Mapper.Map<CreateGameTeamSchemeResponse>(model));
    }

    /// <summary>
    /// Update existing game team scheme.
    /// </summary>
    /// <param name="id">game team scheme unique identifier.</param>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <param name="request">Update game team scheme request.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if game team scheme updated **successfully**.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when scheme **not found** by unique identifier.</response>
    [HttpPut("{id}/Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateGameTeamSchemeAsync([FromRoute] long id, [FromRoute] long gameId, [FromRoute] long teamId, [FromBody] UpdateGameTeamSchemeRequest request)
    {
        UpdateGameTeamSchemeCommand command = Mapper.Map<UpdateGameTeamSchemeCommand>(request)
                                                    .SetSchemeId(id)
                                                    .SetGameId(gameId)
                                                    .SetTeamId(teamId);

        await Mediator.Send(command).ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Delete existing game team scheme.
    /// </summary>
    /// <param name="id">game team scheme unique identifier.</param>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <returns>No content</returns>
    /// <response code="204">Returns no content if game team scheme deleted **successfully**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    /// <response code="404">Returns when scheme **not found** by unique identifier.</response>
    [HttpDelete("{id}/Games/{gameId}/Teams/{teamId}")]
    [Authorize(Policy.OwnTeam)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> DeleteGameTeamSchemeAsync([FromRoute] long id, [FromRoute] long gameId, [FromRoute] long teamId)
    {
        DeleteGameTeamSchemeCommand command = new() { Scheme = new() { Id = id, GameId = gameId, TeamId = teamId } };

        await Mediator.Send(command).ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Return game team scheme model by unique identifier.
    /// </summary>
    /// <param name="id">game team scheme unique identifier.</param>
    /// <param name="gameId">Game Id.</param>
    /// <param name="teamId">Team Id.</param>
    /// <returns>An ActionResult of type GetTeamSchemeResponse</returns>
    /// <response code="200">Returns scheme model.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="404">Returns when scheme **not found** by unique identifier.</response>
    [HttpGet("{id}/Games/{gameId}/Teams/{teamId}", Name = "GetGameTeamScheme")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetGameTeamSchemeResponse>> GetGameTeamSchemeAsync([FromRoute] long id, [FromRoute] long gameId, [FromRoute] long teamId)
    {
        GetGameTeamSchemeQuery query = new() { Id = id, GameId = gameId, TeamId = teamId };

        GetGameTeamSchemeViewModel scheme = await Mediator.Send(query).ConfigureAwait(false);

        return Ok(Mapper.Map<GetGameTeamSchemeResponse>(scheme));
    }

    /// <summary>
    /// Return list of game team schemes
    /// </summary>
    /// <param name="teamId">Team Id.</param>
    /// <param name="gameId">Game Id.</param>
    /// <param name="request">Get game team schemes request.</param>
    /// <returns>An ActionResult of type GetTeamSchemesResponse</returns>
    /// <response code="200">Returns list of game team schemes with pagination header.</response>
    /// <response code="400">Returns **validation** errors.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    [HttpGet("Games/{gameId}/Teams/{teamId}/Find")]
    [Authorize(Policy.General)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<GetGameTeamSchemesResponse>> GetGameTeamSchemesAsync([FromRoute] long gameId, [FromRoute] long teamId, [FromQuery] GetGameTeamSchemesRequest request)
    {
        BasePaginationRequest<GetGameTeamSchemesViewModel, GetGameTeamSchemesFilterDto> query = Mapper.Map<GetGameTeamSchemesQuery>(request)
                                                                                                      .SetGameId(gameId)
                                                                                                      .SetTeamId(teamId);

        GetGameTeamSchemesViewModel result = await Mediator.Send(query).ConfigureAwait(false);

        PageMetadataModel metadata = Mapper.Map<PageMetadataModel>(result.Metadata)
                                           .SetLinks(UriService, Request.QueryString.Value!, Request.Path.Value!);

        Response.AddPaginationHeader(metadata);

        return Ok(Mapper.Map<GetGameTeamSchemesResponse>(result));
    }
}