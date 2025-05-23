using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SFC.Scheme.Api.Infrastructure.Models.Base;
using SFC.Scheme.Api.Infrastructure.Models.Scheme.Data.GetAll;
using SFC.Scheme.Application.Features.Scheme.Data.Queries.GetAll;
using SFC.Scheme.Infrastructure.Constants;

namespace SFC.Scheme.Api.Controllers;

[Tags("Data Schemes")]
[Route("api/Schemes/Data")]
[Authorize(Policy.General)]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(BaseResponse), StatusCodes.Status403Forbidden)]
public class SchemeDataController : ApiControllerBase
{
    /// <summary>
    /// Return all available data types.
    /// </summary>
    /// <returns>An ActionResult of type GetAllResponse</returns>
    /// <response code="200">Returns all available **data types**.</response>
    /// <response code="401">Returns when **failed** authentication.</response>
    /// <response code="403">Returns when **failed** authorization.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetAllSchemeDataResponse>> GetAllAsync()
    {
        GetAllSchemeDataQuery query = new();

        GetAllSchemeDataViewModel model = await Mediator.Send(query).ConfigureAwait(true);

        return Ok(Mapper.Map<GetAllSchemeDataResponse>(model));
    }
}